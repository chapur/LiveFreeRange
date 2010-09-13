using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;
using LiveFreeRange.Operational;

public partial class CheckOut : BasePage
{
    private decimal _totalCounter;
    private PayPalInformation payPalInformation;
    private PayPalManager payPal;
    private string token;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Request.IsSecureConnection)
        //{
        //    Response.Redirect(this.UrlBaseSSL);
        //}
          if (!IsPostBack)
        {
            token = Request.QueryString["token"];
            if (!string.IsNullOrEmpty(token))
            {
                payPalInformation = new PayPalInformation();
                payPalInformation.Order = this.CurrentOrder;
                payPal = new PayPalManager();
                payPalInformation = payPal.GetExpressCheckoutDetails(payPalInformation, token);
            }
            this.LoadShoppingCart();
            this.LoadInformation();
        }
    }

    private void LoadInformation()
    {
        txtFirstName.Text = this.CurrentEndUser.FirstName;
        txtLastName.Text = this.CurrentEndUser.LastName;

        //populate shipping address information
        txtAddress.Text = this.CurrentEndUser.Address.AddressLine;
        txtAddress2.Text = this.CurrentEndUser.Address.AddressLine2;
        txtCity.Text = this.CurrentEndUser.Address.City;
        txtPostalCode.Text = this.CurrentEndUser.Address.PostalCode;
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
        if (this.IsValid)
        {

            this.CurrentEndUser.FirstName = this.txtFirstName.Text;
            this.CurrentEndUser.LastName = this.txtLastName.Text;
            this.CurrentEndUser.Address.AddressLine = this.txtAddress.Text;
            this.CurrentEndUser.Address.AddressLine2 = this.txtAddress2.Text;
            this.CurrentEndUser.Address.City = this.txtCity.Text;
            this.CurrentEndUser.Address.PostalCode = this.txtPostalCode.Text;

            this.CurrentOrder = new Orders();
            this.CurrentOrder.Enduser.FirstName = this.txtFirstName.Text;
            this.CurrentOrder.Enduser.LastName = this.txtLastName.Text;

            this.CurrentOrder.ShippingAddress.AddressLine = this.txtAddress.Text;
            this.CurrentOrder.ShippingAddress.AddressLine2 = this.txtAddress2.Text;
            this.CurrentOrder.ShippingAddress.City = this.txtCity.Text;
            this.CurrentOrder.ShippingAddress.PostalCode = this.txtPostalCode.Text;

            this.CurrentOrder.CreditCard.CardType = this.ddlCreditCardType.SelectedItem.Value;
            this.CurrentOrder.CreditCard.Number = this.txtCreditCardNumber.Text;
            this.CurrentOrder.CreditCard.SecurityCode = this.txtSecurityCode.Text;
            this.CurrentOrder.CreditCard.ExpMonth = int.Parse(this.ddlExpMonth.SelectedItem.Text);
            this.CurrentOrder.CreditCard.ExpYear = int.Parse(this.ddlExpYear.SelectedItem.Text);

            this.CurrentOrder.CreditCard.Address.AddressLine = this.txtBillingAddress.Text;
            this.CurrentOrder.CreditCard.Address.AddressLine2 = this.txtBillingAddress2.Text;
            this.CurrentOrder.CreditCard.Address.City = this.txtBillingCity.Text;
            this.CurrentOrder.CreditCard.Address.PostalCode = this.txtBillingPostalCode.Text;

            this.litTax.Text = this.litTax.Text.Replace("£", "");
            this.CurrentOrder.Tax = Convert.ToDecimal(litTax.Text);

            this.litSubTotal.Text = this.litSubTotal.Text.Replace("£", "");
            this.CurrentOrder.SubTotal = Convert.ToDecimal(this.litSubTotal.Text);

            this.CurrentOrder.ShippingTotal = Convert.ToDecimal(ddlShippingOption.SelectedItem.Value);

            Response.Redirect("CheckOutConfirm.aspx");
        }
    }

    //Get PayPal Token and redirect to pay pal
    protected void ibGetPaypalToken_Click(object sender, ImageClickEventArgs e)
    {
        //set the Order object
        if (this.IsValid)
        {
            this.CurrentOrder = new Orders();
            this.litTax.Text = this.litTax.Text.Replace("£", "");
            this.CurrentOrder.Tax = Math.Round(Convert.ToDecimal(litTax.Text),2);

            this.litSubTotal.Text = this.litSubTotal.Text.Replace("£", "");
            this.CurrentOrder.SubTotal = Math.Round(Convert.ToDecimal(this.litSubTotal.Text),2);

            this.CurrentOrder.ShippingTotal = Math.Round(Convert.ToDecimal(ddlShippingOption.SelectedItem.Value));


            //add order object to paypal information object
            PayPalManager payPal = new PayPalManager();
            PayPalInformation payPalInformation = new PayPalInformation();
            payPalInformation.Order = this.CurrentOrder;

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
            {
                
                Response.Redirect(PayPalManager.GetPaypalFormSubmissionUrl() + "?cmd=_express-checkout&token=" + payPalToken);
            }
            //else
            //{
            //    //find error placeholder, show and add error message
            //    this.pnlOrderDeclined.Visible = true;
            //    this.lblTransactionFailureMessage.Text = payPalToken;
            //}

            
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
