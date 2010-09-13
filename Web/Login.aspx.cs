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

public partial class Login : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtUsername.Focus();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            EndUser endUser = new EndUser();
            ProcessEndUserLogin processLogin = new ProcessEndUserLogin();
            endUser.ContactInformation.Email = txtUsername.Text;
            endUser.Password = txtPassword.Text;
            processLogin.EndUser = endUser;

            try
            {
                processLogin.Invoke();
            }
            catch(Exception ex)
            {
                Response.Redirect("ErrorPage.aspx");
            }

            if (processLogin.IsAuthenticated)
            {
                base.CurrentEndUser = processLogin.EndUser;

                if (Request.Cookies["ReturnUrl"] != null)
                {
                    Response.Redirect(Request.Cookies["ReturnUrl"].Value);
                }
                else
                {
                    Response.Redirect("Account/CustomerOrder.aspx");
                }
            }
            else
            {
                this.litMessage.Text = "Invalid Login!";
            }
        }

    }
}
