using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LiveFreeRange.Common;
using LiveFreeRange.Operational;
using LiveFreeRange.BusinessLogic;

public partial class CheckoutReceipt : BasePage
{
    public string isExpressCheckout { get; set; }

    private string CartGUID
    {
        get { return Utilities.GetCartGUID(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.isExpressCheckout = Request.QueryString["ec"];

        if (!IsPostBack)
        {
            if(this.isExpressCheckout != "true")
                this.SubmitOrder();
        }
    }

    private void SubmitOrder()
    {
        PayPalManager payPal = new PayPalManager();
        PayPalInformation _payPalInformation = new PayPalInformation();

        _payPalInformation.Order = this.CurrentOrder;
        payPal.ProcessDirectPayment(_payPalInformation);

        //if payment successful - add Order to database and display
        if (payPal.IsSubmissionSuccess)
        {
            this.pnlSuccess.Visible = true;
            this.litOrderTotal.Text = string.Format("{0:c}", _payPalInformation.Order.OrderTotal);
            this.litTransactionId.Text = this.CurrentOrder.TransactionId;

            ProcessAddOrder addOrder = new ProcessAddOrder();
            addOrder.Orders = this.CurrentOrder;

            //when the order is added to the db must update stock level.
            //and also delete the corresponding baskets.

            try
            {
                addOrder.Invoke();
            }
            catch(Exception ex)
            {
                Response.Redirect("ErrorPage.aspx");
            }

            this.UpdateStockLevel();
            this.DeleteShoppingCart();
        }
        else
        {
            this.pnlFailure.Visible = true;
            this.litErrorMessage.Text = payPal.SubmissionError;
        }
    }

    private void DeleteShoppingCart()
    {
        ShoppingCart shoppingCart = new ShoppingCart();
        shoppingCart.CartGuid = this.CartGUID;

        ProcessGetShoppingCart getShoppingCart = new ProcessGetShoppingCart();
        getShoppingCart.ShoppingCart = shoppingCart;

        try
        {
            getShoppingCart.Invoke();
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPage.aspx");
        }

        ProcessDeleteShoppingCartByGuid deleteCart = new ProcessDeleteShoppingCartByGuid();
        deleteCart.ShoppingCart = getShoppingCart.ShoppingCart;

        try
        {
            deleteCart.Invoke();
            Utilities.DeleteCartGUID();
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPage.aspx");
        }
    }

    protected void UpdateStockLevel()
    {
        ShoppingCart shoppingCart = new ShoppingCart();
        shoppingCart.CartGuid = this.CartGUID;

        ProcessGetShoppingCart getShoppingCart = new ProcessGetShoppingCart();
        getShoppingCart.ShoppingCart = shoppingCart;


        ProcessUpdateStockLevel updateStockLevel = new ProcessUpdateStockLevel();

        try
        {
            getShoppingCart.Invoke();
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPage.aspx");
        }

        updateStockLevel.ShoppingCart = getShoppingCart.ShoppingCart;

        try
        {
            updateStockLevel.Invoke();
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPage.aspx");
        }
    }
}
