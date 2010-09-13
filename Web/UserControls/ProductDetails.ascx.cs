using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;

public partial class UserControls_ProductDetails : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LoadProduct();
            this.hlContinueShopping.NavigateUrl = "Catalogue.aspx?CategoryId=" + Request.QueryString["CategoryId"];
        }
    }

    private void LoadProduct()
    {
        Product prod = new Product();
        prod.ProductId = int.Parse(Request.QueryString["ProductId"]);
        ProcessGetProductByProductId getProduct = new ProcessGetProductByProductId();
        getProduct.Product = prod;

        try
        {
            getProduct.Invoke();
        }
        catch (Exception ex)
        {
            this.litError.Text = ex.StackTrace;
        }

        this.litProductName.Text = getProduct.Product.Name;
        this.litProductDescription.Text = getProduct.Product.Description;
        this.litPrice.Text = string.Format("{0:}", getProduct.Product.Price);
        this.imgProduct.ImageUrl = "images/Catalogue/large/" + getProduct.Product.ImageUrl;

        this.LoadSizes(prod.Name, prod.ProductColour.ProductColourId);
    }

    private void LoadSizes(string productName, int productColourId)
    {
        ProcessGetProductsByName processProducts = new ProcessGetProductsByName();
        processProducts.ProductName = productName;
        processProducts.ProductColourId = productColourId;
        processProducts.Invoke();

        string stockLevel = processProducts.ResultSet.Tables[0].Rows[0]["StockLevel"].ToString();

        this.ddlSizes.DataTextField = "Availability";
        this.ddlSizes.DataValueField = "ProductSizeId";
        this.ddlSizes.DataSource = processProducts.ResultSet;
        this.ddlSizes.DataBind();
    }

    protected void btnAddToBasket_Click(object sender, EventArgs e)
    {
        string productId = Request.QueryString["ProductId"];
        int quantity = int.Parse(this.txtQuantity.Text);

        Response.Redirect("AddToCart.aspx?ProductId=" + productId + "&Quantity=" + quantity);
    }
}
