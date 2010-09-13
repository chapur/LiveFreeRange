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
using System.Data.SqlTypes;

using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;
using LiveFreeRange.Operational;
using LiveFreeRange.Operational;

public partial class Admin_OrderDetails : System.Web.UI.Page
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			LoadOrderStatus();
			LoadOrderDetails();
		}
	}

	private void LoadOrderDetails()
	{
		ProcessGetOrderDetails processDetails = new ProcessGetOrderDetails();
		ProcessGetOrderById processOrder = new ProcessGetOrderById();

		OrderDetails orderDetails = new OrderDetails();
		orderDetails.OrderId = int.Parse( Request.QueryString[ "OrderId" ] );
		processDetails.OrderDetails = orderDetails;

		Orders orders = new Orders();
		orders.OrderId = int.Parse( Request.QueryString[ "OrderId" ] );
		processOrder.Orders = orders;

		try
		{
			processDetails.Invoke();
			processOrder.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
		
		gvOrderDetailsProducts.DataSource = processDetails.ResultSet;
		gvOrderDetailsProducts.DataBind();

		litTransactionID.Text = Request.QueryString[ "TransId" ];

		if ( orders.ShipDate != DateTime.MinValue )
		{
			txtShippedDate.Text = orders.ShipDate.ToShortDateString();
		}
		txtTrackingNumber.Text = orders.TrackingNumber;

		ddlOrderStatus.SelectedIndex = ddlOrderStatus.Items.IndexOf( ddlOrderStatus.Items.FindByValue( orders.OrderStatusId.ToString() ) );
	}

	private void LoadOrderStatus()
	{
		ProcessGetOrderStatus processOrderStatus = new ProcessGetOrderStatus();

		try
		{
			processOrderStatus.Invoke();
		}
		catch(Exception ex)
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}

		ddlOrderStatus.DataTextField = "OrderStatusName";
		ddlOrderStatus.DataValueField = "OrderStatusID";
		ddlOrderStatus.DataSource = processOrderStatus.ResultSet;
		ddlOrderStatus.DataBind();
	}

	protected void btnUpdate_Click( object sender , EventArgs e )
	{
		Orders orders = new Orders();
		ProcessUpdateOrder updateOrder = new ProcessUpdateOrder();

		orders.OrderId = int.Parse( Request.QueryString["OrderId"] );
		orders.OrderStatusId = int.Parse( ddlOrderStatus.SelectedItem.Value );
		orders.ShipDate = Convert.ToDateTime( txtShippedDate.Text );
		orders.TrackingNumber = txtTrackingNumber.Text;

		updateOrder.Orders = orders;

		try
		{
			updateOrder.Invoke();

			EmailManager emailMngr = new EmailManager();
			EmailContents mailContents = new EmailContents();

            mailContents.To = Request.QueryString[ "Email" ];
			mailContents.Subject = "Live Free Range Update - Order ID: " + Request.QueryString["OrderId"];
			mailContents.Body = "Your order has been updated.  Please log into your account for details.";
            mailContents.FromEmailAddress = "jb@livefreerange.co.uk";
			emailMngr.Send( mailContents );

            if ( !emailMngr.IsSent )
            {
                Response.Redirect("../ErrorPage.aspx");
            }
		}
		catch(Exception ex)
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}

		Response.Redirect( "Orders.aspx" );
	}

	protected void btnRefund_Click( object sender , EventArgs e )
	{
		PayPalManager payPal = new PayPalManager();
		payPal.RefundTransaction( Request.QueryString[ "TransId" ] );

        Orders orders = new Orders();
		ProcessUpdateOrder updateOrder = new ProcessUpdateOrder();

        int refundedstatustype = 3;

		orders.OrderId = int.Parse( Request.QueryString["OrderId"] );
        orders.OrderStatusId = refundedstatustype;
        orders.ShipDate = ( DateTime ) SqlDateTime.Null;
		updateOrder.Orders = orders;

        try
        {
            updateOrder.Invoke();

            if (payPal.IsSubmissionSuccess)
            {
                EmailManager emailMngr = new EmailManager();
                EmailContents mailContents = new EmailContents();

                mailContents.To = Request.QueryString["Email"];
                mailContents.Bcc = EmailAddressConstants.Simon;
                mailContents.Subject = "Live Free Range Update - Order ID: " + Request.QueryString["OrderID"];
                mailContents.Body = "Your order has been refunded.  Please log into your account for details.";
                mailContents.FromEmailAddress = EmailAddressConstants.Contact;

                emailMngr.Send(mailContents);

                if (!emailMngr.IsSent)
                {
                    Response.Redirect("../ErrorPage.aspx");
                }
            }
        }
        catch(Exception ex)
        {
            Response.Redirect("../ErrorPage.aspx");
        }

        Response.Redirect("Orders.aspx");
	}

	protected void btnReturn_Click( object sender , EventArgs e )
	{
		Response.Redirect( "Orders.aspx" );
	}

	protected void imagebuttonDatePicker_Click( object sender , ImageClickEventArgs e )
	{
		if ( calendarDatePicker.Visible )
		{
			this.calendarDatePicker.Visible = false;
		}
		else
		{
			this.calendarDatePicker.Visible = true;
		}
	}

	protected void calendarDatePicker_SelectionChanged( object sender , EventArgs e )
	{
		this.txtShippedDate.Text = calendarDatePicker.SelectedDate.ToShortDateString();
		this.calendarDatePicker.Visible = false;
	}
}
