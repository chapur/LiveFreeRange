using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using LiveFreeRange.BusinessLogic;
using LiveFreeRange.Operational;
using LiveFreeRange.Common;

public partial class UserControls_CheckOut : BaseControl
{
    private decimal _totalCounter;
    
    private string CartGUID
    {
        get { return Utilities.GetCartGUID(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Request.IsSecureConnection)
        //{
        //    Response.Redirect(base.UrlBaseSSL);
        //}

        if (!IsPostBack)
        {
            this.LoadShoppingCart();
            this.LoadInformation();
        }
    }

    private void LoadInformation()
    {
        txtFirstName.Text = this.LiveFreeRangePage.CurrentEndUser.FirstName;
        txtLastName.Text = this.LiveFreeRangePage.CurrentEndUser.LastName;

        //populate shipping address information
        txtAddress.Text = this.LiveFreeRangePage.CurrentEndUser.Address.AddressLine;
        txtAddress2.Text = this.LiveFreeRangePage.CurrentEndUser.Address.AddressLine2;
        txtCity.Text = this.LiveFreeRangePage.CurrentEndUser.Address.City;
        txtPostalCode.Text = this.LiveFreeRangePage.CurrentEndUser.Address.PostalCode;
    }

    protected void gvShoppingCart_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            _totalCounter += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalPrice"));
        }

        this.litSubTotal.Text = string.Format("{0:c}", _totalCounter);
        this.litTax.Text = string.Format("{0:c}", (CalculationManager.CalcSalesTax(_totalCounter)));
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
            this.gvShoppingCart.DataSource = processGetCart.ResultSet;
            this.gvShoppingCart.DataBind();
        }
        catch
        {
            Response.Redirect("ErrorPage.aspx");
        }
    }

    //Submit Credit Card Order
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.LiveFreeRangePage.IsValid)
        {
            
            this.LiveFreeRangePage.CurrentEndUser.FirstName = this.txtFirstName.Text;
            this.LiveFreeRangePage.CurrentEndUser.LastName = this.txtLastName.Text;
            this.LiveFreeRangePage.CurrentEndUser.Address.AddressLine = this.txtAddress.Text;
            this.LiveFreeRangePage.CurrentEndUser.Address.AddressLine2 = this.txtAddress2.Text;
            this.LiveFreeRangePage.CurrentEndUser.Address.City = this.txtCity.Text;
            this.LiveFreeRangePage.CurrentEndUser.Address.PostalCode = this.txtPostalCode.Text;

            this.LiveFreeRangePage.CurrentOrder = new Orders();
            this.LiveFreeRangePage.CurrentOrder.Enduser.FirstName = this.txtFirstName.Text;
            this.LiveFreeRangePage.CurrentOrder.Enduser.LastName = this.txtLastName.Text;

            this.LiveFreeRangePage.CurrentOrder.ShippingAddress.AddressLine = this.txtAddress.Text;
            this.LiveFreeRangePage.CurrentOrder.ShippingAddress.AddressLine2 = this.txtAddress2.Text;
            this.LiveFreeRangePage.CurrentOrder.ShippingAddress.City = this.txtCity.Text;
            this.LiveFreeRangePage.CurrentOrder.ShippingAddress.PostalCode = this.txtPostalCode.Text;

            this.LiveFreeRangePage.CurrentOrder.CreditCard.CardType = this.ddlCreditCardType.SelectedItem.Value;
            this.LiveFreeRangePage.CurrentOrder.CreditCard.Number = this.txtCreditCardNumber.Text;
            this.LiveFreeRangePage.CurrentOrder.CreditCard.SecurityCode = this.txtSecurityCode.Text;
            this.LiveFreeRangePage.CurrentOrder.CreditCard.ExpMonth = int.Parse(this.ddlExpMonth.SelectedItem.Text);
            this.LiveFreeRangePage.CurrentOrder.CreditCard.ExpYear = int.Parse(this.ddlExpYear.SelectedItem.Text);

            this.LiveFreeRangePage.CurrentOrder.CreditCard.Address.AddressLine = this.txtBillingAddress.Text;
            this.LiveFreeRangePage.CurrentOrder.CreditCard.Address.AddressLine2 = this.txtBillingAddress2.Text;
            this.LiveFreeRangePage.CurrentOrder.CreditCard.Address.City = this.txtBillingCity.Text;
            this.LiveFreeRangePage.CurrentOrder.CreditCard.Address.PostalCode = this.txtBillingPostalCode.Text;

            this.litTax.Text = this.litTax.Text.Replace("£", "");
            this.LiveFreeRangePage.CurrentOrder.Tax = Convert.ToDecimal(litTax.Text);

            this.litSubTotal.Text = this.litSubTotal.Text.Replace("£", "");
            this.LiveFreeRangePage.CurrentOrder.SubTotal = Convert.ToDecimal(this.litSubTotal.Text);

            this.LiveFreeRangePage.CurrentOrder.ShippingTotal = Convert.ToDecimal(ddlShippingOption.SelectedItem.Value);

            Response.Redirect("CheckOut/CheckOutConfirm.aspx");
        }
    }

    //Get PayPal Token and redirect to pay pal
    protected void ibGetPaypalToken_Click(object sender, ImageClickEventArgs e)
    {
        //set the Order object
        if (this.LiveFreeRangePage.IsValid)
        {
            //this.LiveFreeRangePage.CurrentEndUser.FirstName = this.txtFirstName.Text;
            //this.LiveFreeRangePage.CurrentEndUser.LastName = this.txtLastName.Text;
            //this.LiveFreeRangePage.CurrentEndUser.Address.AddressLine = this.txtAddress.Text;
            //this.LiveFreeRangePage.CurrentEndUser.Address.AddressLine2 = this.txtAddress2.Text;
            //this.LiveFreeRangePage.CurrentEndUser.Address.City = this.txtCity.Text;
            //this.LiveFreeRangePage.CurrentEndUser.Address.PostalCode = this.txtPostalCode.Text;

            //this.LiveFreeRangePage.CurrentOrder = new Orders();
            //this.LiveFreeRangePage.CurrentOrder.Enduser.FirstName = this.txtFirstName.Text;
            //this.LiveFreeRangePage.CurrentOrder.Enduser.LastName = this.txtLastName.Text;

            //this.LiveFreeRangePage.CurrentOrder.ShippingAddress.AddressLine = this.txtAddress.Text;
            //this.LiveFreeRangePage.CurrentOrder.ShippingAddress.AddressLine2 = this.txtAddress2.Text;
            //this.LiveFreeRangePage.CurrentOrder.ShippingAddress.City = this.txtCity.Text;
            //this.LiveFreeRangePage.CurrentOrder.ShippingAddress.PostalCode = this.txtPostalCode.Text;

            //this.LiveFreeRangePage.CurrentOrder.CreditCard.CardType = this.ddlCreditCardType.SelectedItem.Value;
            //this.LiveFreeRangePage.CurrentOrder.CreditCard.Number = this.txtCreditCardNumber.Text;
            //this.LiveFreeRangePage.CurrentOrder.CreditCard.SecurityCode = this.txtSecurityCode.Text;
            //this.LiveFreeRangePage.CurrentOrder.CreditCard.ExpMonth = int.Parse(this.ddlExpMonth.SelectedItem.Text);
            //this.LiveFreeRangePage.CurrentOrder.CreditCard.ExpYear = int.Parse(this.ddlExpYear.SelectedItem.Text);

            //this.LiveFreeRangePage.CurrentOrder.CreditCard.Address.AddressLine = this.txtBillingAddress.Text;
            //this.LiveFreeRangePage.CurrentOrder.CreditCard.Address.AddressLine2 = this.txtBillingAddress2.Text;
            //this.LiveFreeRangePage.CurrentOrder.CreditCard.Address.City = this.txtBillingCity.Text;
            //this.LiveFreeRangePage.CurrentOrder.CreditCard.Address.PostalCode = this.txtBillingPostalCode.Text;

            this.LiveFreeRangePage.CurrentOrder = new Orders();
            this.litTax.Text = this.litTax.Text.Replace("£", "");
            this.LiveFreeRangePage.CurrentOrder.Tax = Convert.ToDecimal(litTax.Text);

            this.litSubTotal.Text = this.litSubTotal.Text.Replace("£", "");
            this.LiveFreeRangePage.CurrentOrder.SubTotal = Convert.ToDecimal(this.litSubTotal.Text);

            this.LiveFreeRangePage.CurrentOrder.ShippingTotal = Convert.ToDecimal(ddlShippingOption.SelectedItem.Value);


            //add order object to paypal information object
            PayPalManager payPal = new PayPalManager();
            PayPalInformation payPalInformation = new PayPalInformation();
            payPalInformation.Order = this.LiveFreeRangePage.CurrentOrder;

            //set required url's
            string payPalSubmitUrl = string.Empty;

            if (!(PayPalManager.IsPaypalSandboxOn()))
                payPalSubmitUrl = "https://www.livefreerange.com";
            else
                payPalSubmitUrl = "http://localhost/Web/CheckOut/CheckOut.aspx";

            string payPalCancelUrl = payPalSubmitUrl;

            //pass paypal information to setexpresscheckout and return a token.
            string payPalToken = payPal.SetExpressCheckout(payPalInformation, payPalSubmitUrl, payPalCancelUrl);

            //redirect to paypal with token
            if (payPalToken.ToLower().IndexOf("error") == -1)
                Response.Redirect(PayPalManager.GetPaypalFormSubmissionUrl()
                    + "?cmd=_express-checkout&token="
                    + payPalToken);
            else
            {
                //find error placeholder, show and add error message
                Panel pnlOrderDeclined = (Panel)Page.FindControl("pnlOrderDeclined");
                pnlOrderDeclined.Visible = true;

                Label lblTransactionFailureMessage = (Label)Page.FindControl("lblTransactionFailureMessage");
                lblTransactionFailureMessage.Text = payPalToken;
            }
        }
    }
    
    //Complete Pay Pal Order
    protected void ibCompletePaypalOrder_Click(object sender, ImageClickEventArgs e)
    {
        //GetExpressCheckoutDetails - required if shipping goods or if we need the billing address

        /*
        APIWrapper ppGetDetails = new APIWrapper();
        APIWrapper.PayerInfo ppInfo = new APIWrapper.PayerInfo();
        ppInfo = ppGetDetails.GetExpressCheckout( 
        */

        string token = Request.QueryString["token"];
        string payerId = Request.QueryString["PayerID"];

        //DoExpressCheckoutPayment
        PayPalManager payPal = new PayPalManager();
        PayPalInformation payPalInformation = new PayPalInformation();
        payPalInformation.Order = this.LiveFreeRangePage.CurrentOrder;


        // #HACK: WJ: sub null for items array below to get it working
        PayPalManager.OrderInfo ppOrderInfo = new PayPalManager.OrderInfo();

        //this call returns an order info object
        //double orderTotal = Convert.ToDouble(this.CommercePage.Basket.GetBaseTotalAfterDiscount());

        this.LiveFreeRangePage.CurrentOrder = new Orders();
        double orderTotal = Convert.ToDouble(this.LiveFreeRangePage.CurrentOrder.SubTotal);

        // this call actually processes the payment
        ppOrderInfo =  payPal.DoExpressCheckout(token, payPalInformation);

        string ack = ppOrderInfo.Ack; // says "Success" or "ERROR:..."
        string transactionId = ppOrderInfo.TransactionID;
        string receiptId = ppOrderInfo.ReceiptID;

        // handle Paypal web service response
        if (ack.IndexOf("ERROR") != -1)
        {
            //find error placeholder, show and add error message
            ContentPlaceHolder cph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

            Panel pnlOrderDeclined = (Panel)cph.FindControl("pnlOrderDeclined");
            pnlOrderDeclined.Visible = true;

            Label lblTransactionFailureMessage = (Label)cph.FindControl("lblTransactionFailureMessage");
            lblTransactionFailureMessage.Text = ack;

            // also need to show a credit card payment option - to do.
        }
        else
        {
            // Transaction successful: complete order!
            ProcessAddOrder addOrder = new ProcessAddOrder();
            addOrder.Orders = this.LiveFreeRangePage.CurrentOrder;

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
            Response.Redirect("~/Web/CheckOutReceipt.aspx");
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
            //delete cart cookie
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

    protected void rblPaymentType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.rblPaymentType.SelectedItem.Value == "CC")
        {
            this.phCreditCard.Visible = true;
            this.phPayPal.Visible = false;
        }
        else
        {
            this.phCreditCard.Visible = false;
            this.phPayPal.Visible = true;
        }
    }
}
