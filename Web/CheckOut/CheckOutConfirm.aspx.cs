using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;
using LiveFreeRange.Operational;

public partial class CheckOutConfirm : BasePage 
{
    private string CartGUID
    {
        get { return Utilities.GetCartGUID(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //need to set up secure testing.
        //if (!Request.IsSecureConnection)
        //{
        //    Response.Redirect(base.UrlBaseSSL);
        //}

        string token = Request.QueryString["token"];
        if (string.IsNullOrEmpty(token))
        {
            this.phCreditCard.Visible = true;
            this.phPayPal.Visible = false;
        }
        else
        {
            this.phPayPal.Visible = true;
            this.phCreditCard.Visible = false;
        }

        if (!IsPostBack)
        {
            this.LoadShoppingCart();
            this.LoadInformation();
        }
    }

    private void LoadInformation()
    {
        this.litFirstname.Text = base.CurrentEndUser.FirstName;
        this.litLastname.Text = base.CurrentEndUser.LastName;
        this.litAddress.Text = base.CurrentEndUser.Address.AddressLine;
        this.litAddress2.Text = base.CurrentEndUser.Address.AddressLine2;
        this.litCity.Text = base.CurrentEndUser.Address.City;
        this.litPostalCode.Text = base.CurrentEndUser.Address.PostalCode;

        this.litCreditCardType.Text = base.CurrentOrder.CreditCard.CardType;
        this.litCreditCardNumber.Text = base.CurrentOrder.CreditCard.Number;
        this.litCreditCardSecurityCode.Text = base.CurrentOrder.CreditCard.SecurityCode;
        this.litExpirationDate.Text = base.CurrentOrder.CreditCard.ExpMonth.ToString() + "/" + base.CurrentOrder.CreditCard.ExpYear.ToString();

        this.litBillingAddress.Text = base.CurrentOrder.CreditCard.Address.AddressLine;
        this.litBillingAddress2.Text = base.CurrentOrder.CreditCard.Address.AddressLine2;
        this.litBillingCity.Text = base.CurrentOrder.CreditCard.Address.City;
        this.litBillingPostalCode.Text = base.CurrentOrder.CreditCard.Address.PostalCode;

        this.litSubTotal.Text = string.Format("{0:c}", base.CurrentOrder.SubTotal);
        this.litTax.Text = string.Format("{0:c}", base.CurrentOrder.Tax);
        this.litShippingCost.Text = string.Format("{0:c}", base.CurrentOrder.ShippingTotal);

        this.litTotal.Text = string.Format("{0:c}", Convert.ToDecimal(base.CurrentOrder.SubTotal) + base.CurrentOrder.Tax + base.CurrentOrder.ShippingTotal);
    }

    private void LoadShoppingCart()
    {
        LiveFreeRange.Common.ShoppingCart shoppingCart = new LiveFreeRange.Common.ShoppingCart();
        shoppingCart.CartGuid = Utilities.GetCartGUID();

        ProcessGetShoppingCart processGetCart = new ProcessGetShoppingCart();
        processGetCart.ShoppingCart = shoppingCart;

        try
        {
            processGetCart.Invoke();
            gvShoppingCart.DataSource = processGetCart.ResultSet;
            gvShoppingCart.DataBind();
        }
        catch(Exception ex)
        {
            Response.Redirect("ErrorPage.aspx");
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //navigate back to the previous page
        Response.Redirect("Checkout.aspx");
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Product[] products = new Product[gvShoppingCart.Rows.Count];
        foreach (GridViewRow row in gvShoppingCart.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                Product prod = new Product();

                DataKey data = gvShoppingCart.DataKeys[row.DataItemIndex];

                prod.ProductId = int.Parse(data.Values["ProductId"].ToString());

                Literal litProductName = (Literal)row.FindControl("litProductName");
                prod.Name = litProductName.Text;

                Literal litQuantity = (Literal)row.FindControl("litQuantity");
                prod.Quantity = int.Parse(litQuantity.Text);

                Literal litUnitPrice = (Literal)row.FindControl("litUnitPrice");
                litUnitPrice.Text = litUnitPrice.Text.Replace("£", "");
                prod.Price = Convert.ToDecimal(litUnitPrice.Text);

                products.SetValue(prod, row.DataItemIndex);
            }
        }

        CurrentOrder.OrderDetails.Products = products;

        //order total
        this.litTotal.Text = this.litTotal.Text.Replace("£", "");
        this.CurrentOrder.OrderTotal = Convert.ToDecimal(this.litTotal.Text);
        this.CurrentOrder.EndUserId = this.CurrentEndUser.EndUserId;

        string url = "CheckOutReceipt.aspx";
        Response.Redirect("Loading.aspx?Page=" + url);

    }

    protected void ibCompletePaypalOrder_Click(object sender, ImageClickEventArgs e)
    {
        Product[] products = new Product[gvShoppingCart.Rows.Count];
        foreach (GridViewRow row in gvShoppingCart.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                Product prod = new Product();

                DataKey data = gvShoppingCart.DataKeys[row.DataItemIndex];

                prod.ProductId = int.Parse(data.Values["ProductId"].ToString());

                Literal litProductName = (Literal)row.FindControl("litProductName");
                prod.Name = litProductName.Text;

                Literal litQuantity = (Literal)row.FindControl("litQuantity");
                prod.Quantity = int.Parse(litQuantity.Text);

                Literal litUnitPrice = (Literal)row.FindControl("litUnitPrice");
                litUnitPrice.Text = litUnitPrice.Text.Replace("£", "");
                prod.Price = Convert.ToDecimal(litUnitPrice.Text);

                products.SetValue(prod, row.DataItemIndex);
            }
        }

        CurrentOrder.OrderDetails.Products = products;

        //order total
        this.litTotal.Text = this.litTotal.Text.Replace("£", "");
        this.CurrentOrder.OrderTotal = Convert.ToDecimal(this.litTotal.Text);
        this.CurrentOrder.EndUserId = this.CurrentEndUser.EndUserId;



        string token = Request.QueryString["token"];
        string payerId = Request.QueryString["PayerID"];

        //DoExpressCheckoutPayment
        PayPalManager payPal = new PayPalManager();
        PayPalInformation payPalInformation = new PayPalInformation();
        payPalInformation.Order = this.CurrentOrder;
        payPalInformation.Order.PayerId = payerId;
        payPalInformation.Order.SubTotal = this.CurrentOrder.OrderTotal;

        // #HACK: WJ: sub null for items array below to get it working
        PayPalManager.OrderInfo ppOrderInfo = new PayPalManager.OrderInfo();

        //this call returns an order info object
        //double orderTotal = Convert.ToDouble(this.CommercePage.Basket.GetBaseTotalAfterDiscount());

        
        double orderTotal = Math.Round(Convert.ToDouble(base.CurrentOrder.SubTotal), 2);

        // this call actually processes the payment
        ppOrderInfo = payPal.DoExpressCheckout(token, payPalInformation);

        string ack = ppOrderInfo.Ack; // says "Success" or "ERROR:..."
        string transactionId = ppOrderInfo.TransactionID;
        string receiptId = ppOrderInfo.ReceiptID;
        this.CurrentOrder.TransactionId = transactionId;
        // handle Paypal web service response
        if (ack.IndexOf("ERROR") != -1)
        {
            //find error placeholder, show and add error message
            ContentPlaceHolder cph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

            this.pnlOrderDeclined.Visible = true;

            this.lblTransactionFailureMessage.Text = ack;

            // also need to show a credit card payment option - to do.
        }
        else
        {
            // Transaction successful: complete order!
            ProcessAddOrder addOrder = new ProcessAddOrder();
            addOrder.Orders = this.CurrentOrder;

            try
            {
                addOrder.Invoke();
            }
            catch (Exception ex)
            {
                Response.Redirect("ErrorPage.aspx");
            }
          
            this.UpdateStockLevel();
            this.DeleteShoppingCart();

            // now forward to order completed page
            Response.Redirect("~/CheckOut/CheckOutReceipt.aspx?ec=true");
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
            Utilities.DeleteCartGUID();
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
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPage.aspx");
        }
    }

    private void UpdateStockLevel()
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
        catch(Exception ex)
        {
            Response.Redirect("ErrorPage.aspx");
        }
    }
}
