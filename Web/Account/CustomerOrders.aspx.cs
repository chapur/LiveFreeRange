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

using LiveFreeRange.BusinessLogic;

public partial class Account_CustomerOrders : BasePage
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			Literal litWelcome = ( Literal) Master.FindControl( "litWelcome" );
			litWelcome.Text = "Welcome, " + base.CurrentEndUser.FirstName + " " + base.CurrentEndUser.LastName;
			LoadOrders();
		}
	}

	private void LoadOrders()
	{
		ProcessGetOrders getOrders = new ProcessGetOrders();
		getOrders.EndUser = CurrentEndUser;

		try
		{
			getOrders.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
		
		gvOrders.DataSource = getOrders.ResultSet;
		gvOrders.DataBind();
	}
}
