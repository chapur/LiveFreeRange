using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using LiveFreeRange.Operational;
using LiveFreeRange.BusinessLogic;

public partial class Admin_NewsletterConfirmation : BasePage
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			SendNewsletters();
		}
	}

	private void SendNewsletters()
	{
		ProcessNewsletter processNewsletter = new ProcessNewsletter();
		NewsletterManager newsletterMngr = new NewsletterManager();

		try
		{
			processNewsletter.Invoke();
			newsletterMngr.MessageBody = base.NewsletterBody;
			newsletterMngr.UserData = processNewsletter.ResultSet;
			newsletterMngr.SendNewsletter();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
	}
}
