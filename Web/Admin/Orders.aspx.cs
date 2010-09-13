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

public partial class Admin_Orders : System.Web.UI.Page
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			LoadOrders();
		}
	}

	private void LoadOrders()
	{
		ProcessGetAllOrders getAllOrders = new ProcessGetAllOrders();

		try
		{
			getAllOrders.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}

		gvAllOrders.DataSource = getAllOrders.ResultSet;
		gvAllOrders.DataBind();
	}
}
