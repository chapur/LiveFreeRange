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
using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;

public partial class UserControls_ProductList : System.Web.UI.UserControl
{
    private string _subCategoryId;

    public string SubCategoryId
    {
        get { return _subCategoryId; }
        set { _subCategoryId = value; }
    }
    
    private string _productCategoryId;

    public string ProductCategoryId
    {
        get { return _productCategoryId; }
        set { _productCategoryId = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //dependent on what params are available, accept no Id, ProductCategoryId or ProductCategoryId + SubCategoryId

        Collection<ProductCollection> products = new Collection<ProductCollection>();
        ProcessGetProductsByCategoryId productsCatId = new ProcessGetProductsByCategoryId();
        ProcessGetProductsBySubCategoryId productsSubId = new ProcessGetProductsBySubCategoryId();
        
        if (this.SubCategoryId != null)
        {
            productsSubId.SubCategoryId = Convert.ToInt32(this.SubCategoryId);

            try
            {
                productsSubId.Invoke();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            this.lvProductList.DataSource = productsSubId.Products;
            this.lvProductList.DataBind();
        }

        else if (this.SubCategoryId == null && this.ProductCategoryId != null)
        {
            productsCatId.CategoryId = Convert.ToInt32(this.ProductCategoryId);

            try
            {
                productsCatId.Invoke();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            this.lvProductList.DataSource = productsCatId.Products;
            this.lvProductList.DataBind();
        }
        
        
    }

    protected void lvProductList_OnItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem listViewDataItem = e.Item as ListViewDataItem;
        ProductCollection currentProduct = listViewDataItem.DataItem as ProductCollection;

        Literal litProductName = listViewDataItem.FindControl("litProductName") as Literal;
        litProductName.Text = currentProduct.ProductName;

        Image imgProduct = listViewDataItem.FindControl("imgProduct") as Image;
        imgProduct.ImageUrl = "/web/images/catalogue/small/" + currentProduct.ProductImageUrl;
        imgProduct.AlternateText = currentProduct.ProductName + " - " + currentProduct.ProductDescription;

        HyperLink hlProduct = listViewDataItem.FindControl("hlProduct") as HyperLink;
        hlProduct.NavigateUrl = "/web/ProductDetails.aspx?ProductId=" + currentProduct.ProductId + "&CategoryId=" + currentProduct.CategoryId;

        DropDownList ddlStockLevel = listViewDataItem.FindControl("ddlStockLevel") as DropDownList;
    }
}
