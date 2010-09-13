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

public partial class Admin_Products : System.Web.UI.Page
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			LoadProducts();
		}
	}

	private void LoadProducts()
	{
		ProcessGetProducts processProducts = new ProcessGetProducts();

		try
		{
			processProducts.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}

	    datalistProducts.DataSource = processProducts.ResultSet;
		datalistProducts.DataBind();
	}

	protected void btnAddProduct_Click( object sender , EventArgs e )
	{
		Response.Redirect( "AddProduct.aspx" );
	}
}
