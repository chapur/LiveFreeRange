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
using LiveFreeRange.Operational;

public partial class Account_CustomerOrderDetails : BasePage
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			Literal litWelcome = ( Literal ) Master.FindControl( "litWelcome" );
			litWelcome.Text = "Welcome, " + base.CurrentEndUser.FirstName + " " + base.CurrentEndUser.LastName;

			LoadOrderDetails();
		}
	}

	private void LoadOrderDetails()
	{
		ProcessGetOrderDetails processDetails = new ProcessGetOrderDetails();
		
		OrderDetails orderDetails = new OrderDetails();
		orderDetails.OrderId = int.Parse( Request.QueryString["OrderId"] );
		processDetails.OrderDetails = orderDetails;

		try
		{
			processDetails.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
		
		gvOrderDetailsProducts.DataSource = processDetails.ResultSet;
		gvOrderDetailsProducts.DataBind();

	    litTransactionID.Text = Request.QueryString[ "TransID" ];

		PayPalManager paypal = new PayPalManager();
		Orders ord = new Orders();

		ord.TransactionId = Request.QueryString[ "TransID" ];
		paypal.GetTransactionDetails( ord );

		if ( paypal.IsSubmissionSuccess )
		{
			litOrderTotal.Text = ord.OrderTotal.ToString( "c" );
			litTax.Text = ord.Tax.ToString( "c" );
		}
		else
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
	}

	protected void btnReturn_Click( object sender , EventArgs e )
	{
		Response.Redirect( "CustomerOrders.aspx" );
	}
}
