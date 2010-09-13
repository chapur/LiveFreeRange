using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiveFreeRange.Operational;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            txtName.Focus();

        this.litComment.Text = "Please enter your comment";
        this.litEmail.Text = "Please enter your email address";
        this.litName.Text = "Please enter your name";
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        SendMessage();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.txtComment.Text = "";
        this.txtEmail.Text = "";
        this.txtName.Text = "";
        this.txtName.Focus();
    }

    private void SendMessage()
    {
        if (IsValid)
        {
            EmailContents contents = new EmailContents();
            contents.FromName = this.txtName.Text;
            contents.FromEmailAddress = this.txtEmail.Text;
            contents.Body = this.txtComment.Text;
            contents.Subject = "Website Feedback";

            EmailManager emailMngr = new EmailManager();
            emailMngr.Send(contents);

            if (emailMngr.IsSent)
            {
                Response.Redirect("ContactUsConfirm.aspx");
            }
        }
    }
}
