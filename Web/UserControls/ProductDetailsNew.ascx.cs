using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;
using LiveFreeRange.Operational.Enumerations;
using LiveFreeRange.Operational;

public partial class UserControls_ProductDetailsNew : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtQuantity.Text = "1";
            this.LoadProduct();
            this.hlContinueShopping.NavigateUrl = "~/Catalogue.aspx?CategoryId=" + Request.QueryString["CategoryId"];
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
        this.litPrice.Text = string.Format("{0:c}", getProduct.Product.Price);
        this.imgProduct.ImageUrl = "~/images/Catalogue/large/" + getProduct.Product.ImageUrl;

        this.ddlSizes.DataTextField = "Availability";
        this.ddlSizes.DataValueField = "StockLevel";
        this.ddlSizes.DataSource = getProduct.ProductSize;
        this.ddlSizes.DataBind();
    }

    protected void btnAddToBasket_Click(object sender, EventArgs e)
    {
        string productId = Request.QueryString["ProductId"];
        int quantity = int.Parse(this.txtQuantity.Text);

        int stockLevel = int.Parse(this.ddlSizes.SelectedItem.Value);
        //get size from text value of ddlSizes
        string size = this.ddlSizes.SelectedItem.Text.Substring(0, 1).ToLower();
        int sizeCode = Utilities.GetSize(size);

        if (stockLevel > 0)
            Response.Redirect("AddToCart.aspx?ProductId=" + productId + "&Quantity=" + quantity + "&Size=" + sizeCode);
        else
            this.litOutOfStock.Text = "Sorry, the requested size is out of stock";
    }

   }
