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

public partial class Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtUserName.Focus();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            EndUser endUser = new EndUser();
            ProcessAdminLogin processLogin = new ProcessAdminLogin();

            endUser.ContactInformation.Email = this.txtUserName.Text;
            endUser.Password = this.txtPassword.Text;
            processLogin.EndUser = endUser;

            try
            {
                processLogin.Invoke();
                if (processLogin.IsAuthenticated)
                {
                    FormsAuthentication.RedirectFromLoginPage(this.txtUserName.Text, false);
                }
                else
                {
                    this.litMessage.Text = "Invalid Login";
                }
            }
            catch
            {
                Response.Redirect("../ErrorPage.aspx");
            }
        }
    }
}
