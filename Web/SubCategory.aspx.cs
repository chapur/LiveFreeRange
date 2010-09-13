using System;
using System.Collections;
using System.Collections.ObjectModel;
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
using LiveFreeRange.BusinessLogic;
using LiveFreeRange.Common;

public partial class SubCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ProcessGetProductsBySubCategoryId processProducts = new ProcessGetProductsBySubCategoryId();
        processProducts.SubCategoryId = 1;

        try
        {
            processProducts.Invoke();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }

        this.dlProducts.DataSource = processProducts.Products;
        this.dlProducts.DataBind();
    }

    protected void dlProducts_OnItemDataBound(object sender, DataListItemEventArgs e)
    {
        ProductCollection products = (ProductCollection)e.Item.DataItem;

        Literal litName = e.Item.FindControl("litName") as Literal;
        litName.Text = products.ProductName;
        Literal litColour = e.Item.FindControl("litColour") as Literal;
        litColour.Text = products.ProductColour;    
    }
}
