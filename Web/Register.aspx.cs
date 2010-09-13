using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;

public partial class Register : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtFirstname.Focus();
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        EndUser endUser = new EndUser();
        ProcessAddEndUser processUser = new ProcessAddEndUser();

        if (IsValid)
        {
            endUser.EndUserTypeId = (int)Enums.EndUserType.CUSTOMER;
            endUser.FirstName = this.txtFirstname.Text;
            endUser.LastName = this.txtLastname.Text;
            endUser.Address.AddressLine = this.txtAddress.Text;
            endUser.Address.AddressLine2 = this.txtAddress2.Text;
            endUser.Address.City = this.txtCity.Text;
            endUser.Address.PostalCode = this.txtPostalCode.Text;
            endUser.Password = this.txtPassword.Text;
            endUser.ContactInformation.Email = this.txtEmail.Text;
            endUser.ContactInformation.Phone = this.txtPhone.Text;
            endUser.ContactInformation.Phone2 = this.txtPhone2.Text;
            endUser.ContactInformation.Fax = this.txtFax.Text;
            endUser.IsSubscribed = this.chkNewsletter.Checked;

            processUser.EndUser = endUser;

            try
            {
                processUser.Invoke();
            }
            catch(Exception ex)
            {
                Response.Redirect("ErrorPage.aspx");
            }

            CurrentEndUser = processUser.EndUser;

            if (Request.Cookies["ReturnUrl"].Value != null)
            {
                Response.Redirect(Request.Cookies["ReturnUrl"].Value);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
    }
}
