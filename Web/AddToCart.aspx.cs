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
using LiveFreeRange.Operational;

public partial class AddToCart : System.Web.UI.Page
{
    private string CartGUID
    {
        get { return Utilities.GetCartGUID(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LiveFreeRange.Common.ShoppingCart shoppingCart = new LiveFreeRange.Common.ShoppingCart();
        shoppingCart.ProductId = int.Parse(Request.QueryString["ProductId"]);
        shoppingCart.CartGuid = CartGUID;
        shoppingCart.Quantity = int.Parse(Request.QueryString["Quantity"]);
        //shoppingCart.ProductSize = Request.QueryString["Size"];
        shoppingCart.ProductSizeId = Convert.ToInt32(Request.QueryString["Size"]);

        ProcessAddShoppingCart procShoppingCart = new ProcessAddShoppingCart();

        procShoppingCart.ShoppingCart = shoppingCart;

        try
        {
            procShoppingCart.Invoke();
        }
        catch(Exception ex)
        {
            Response.Write(ex);
        }
        Response.Redirect("ShoppingCart.aspx?ProductId=" + Request.QueryString["ProductId"]);
    }
}
