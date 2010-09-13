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

using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;

public partial class Admin_UnSubscribe : System.Web.UI.Page
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			UnsubscribeCustomer();
			this.litName.Text = Request.QueryString["FullName"];
		}
	}

	private void UnsubscribeCustomer()
	{
		ProcessNewsletterUnsubscribe unsubscribe = new ProcessNewsletterUnsubscribe();
		EndUser endUser = new EndUser();
		endUser.EndUserId = int.Parse( Request.QueryString["EndUserID"] );

		unsubscribe.EndUser = endUser;

		try
		{
			unsubscribe.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
	}
}
