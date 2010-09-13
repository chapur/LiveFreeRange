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

public partial class ShoppingCart : System.Web.UI.Page
{
	private decimal _totalCounter;

	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			LoadShoppingCart();
			LoadPromotion();
		}
	}

	private void LoadShoppingCart()
	{
		LiveFreeRange.Common.ShoppingCart shoppingcart = new LiveFreeRange.Common.ShoppingCart();
		shoppingcart.CartGuid = CartGUID;

		ProcessGetShoppingCart processGetCart = new ProcessGetShoppingCart();
        processGetCart.ShoppingCart = shoppingcart;

		try
		{
            processGetCart.Invoke();
            gvShoppingCart.DataSource = processGetCart.ResultSet;
			gvShoppingCart.DataBind();
		}
		catch(Exception ex)
		{
			Response.Redirect( "ErrorPage.aspx" );
		}
	}

	private void LoadPromotion()
	{
		ProcessGetPromotions getPromotions = new ProcessGetPromotions();
		Product product = new Product();

		if ( Request.QueryString["ProductId"] != null )
		{
			product.ProductId = int.Parse( Request.QueryString["ProductId"] );
		}
		else
		{
			return;
		}

		getPromotions.Product = product;

		try
		{
			getPromotions.Invoke();

			if ( getPromotions.ResultSet.Tables[0].Rows.Count > 0 )
			{
				pnlPromotion.Visible = true;
				gvAssociated.DataSource = getPromotions.ResultSet;
				gvAssociated.DataBind();
			}
		}
		catch
		{
			Response.Redirect( "ErrorPage.aspx" );
		}
	}

	protected void gvShoppingCart_RowDataBound( object sender , GridViewRowEventArgs e )
	{
		if ( e.Row.RowType == DataControlRowType.DataRow )
		{
			_totalCounter += Convert.ToDecimal( DataBinder.Eval( e.Row.DataItem , "TotalPrice" ) );
		}
		
		litTotal.Text = string.Format( "{0:c}" , _totalCounter );
	}

	protected void btnUpdate_Click( object sender , EventArgs e )
	{
		foreach ( GridViewRow row in gvShoppingCart.Rows )
		{
			if ( row.RowType == DataControlRowType.DataRow )
			{
				DataKey data = gvShoppingCart.DataKeys[ row.DataItemIndex ];

				CheckBox check = ( CheckBox ) row.FindControl( "chkDelete" );

				if ( check.Checked )
				{
					Delete( int.Parse( data.Values[ "ShoppingCartID" ].ToString() ) );
				}

				TextBox txtNewQuantity = ( TextBox ) row.FindControl( "txtQuantity" );
				int integerNewQuantity = int.Parse( txtNewQuantity.Text );
				int integerOrigQuantity = int.Parse( gvShoppingCart.DataKeys[ row.DataItemIndex ].Value.ToString() );

				if ( integerNewQuantity != integerOrigQuantity )
				{
					Update( int.Parse( data.Values[ "ShoppingCartID" ].ToString() ) , integerNewQuantity );
				}
			}
		}

		LoadShoppingCart();
	}

	private void Update( int id , int newqty )
	{
		ProcessUpdateShoppingCart processUpdate = new ProcessUpdateShoppingCart();

		LiveFreeRange.Common.ShoppingCart shoppingCart = new LiveFreeRange.Common.ShoppingCart();
		shoppingCart.Quantity = newqty;
		shoppingCart.ShoppingCartId = id;
		processUpdate.ShoppingCart = shoppingCart;

		try
		{
			processUpdate.Invoke();
		}
		catch
		{
			Response.Redirect( "ErrorPage.aspx" );
		}
	}

	private void Delete( int id )
	{
		ProcessDeleteShoppingCart processDelete = new ProcessDeleteShoppingCart();

		LiveFreeRange.Common.ShoppingCart shoppingCart = new LiveFreeRange.Common.ShoppingCart();
		shoppingCart.ShoppingCartId = id;
		processDelete.ShoppingCart = shoppingCart;

		try
		{
			processDelete.Invoke();
		}
		catch
		{
			Response.Redirect( "ErrorPage.aspx" );
		}
	}

	protected void btnCheckout_Click( object sender , EventArgs e )
	{
        //need to first check if an updated quantity is in stock
		Response.Cookies[ "ReturnURL" ].Value = "CheckOut/CheckOut.aspx";
		Response.Redirect( "Login.aspx" );
	}

	private string CartGUID
	{
		get { return Utilities.GetCartGUID(); }
	}

	protected void btnContinueShopping_Click( object sender , EventArgs e )
	{
		Response.Redirect( "Catalogue.aspx" );
	}
}
