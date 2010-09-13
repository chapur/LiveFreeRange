using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;
using LiveFreeRange.Operational;

public partial class Admin_AddProduct : System.Web.UI.Page
{
    private const string SAVEDPRODUCTIMAGEURL = "SavedProductImageUrl";
    private const string SAVEDPRODUCTIMAGEID = "SavedProductImageId";

    private string SavedProductImageUrl
    {
        get { return (string)ViewState[SAVEDPRODUCTIMAGEURL]; }
        set { ViewState[SAVEDPRODUCTIMAGEURL] = value; }
    }

    private int SavedProductImageId
    {
        get { return (int)ViewState[SAVEDPRODUCTIMAGEID]; }
        set { ViewState[SAVEDPRODUCTIMAGEID] = value; }
    }

	protected void Page_Load( object sender , EventArgs e )
	{
        if ( !IsPostBack )
		{
			this.txtProductName.Focus();
			this.LoadCategories();
            this.LoadColour();
            //this.LoadSize();
            this.LoadWeight();
            this.LoadProductName();
		}
	}

    protected void ddlProductNames_OnIndexChanged(object sender, EventArgs e)
    {
        this.txtProductName.Text = this.ddlProductNames.SelectedItem.Text;
        if (int.Parse(this.ddlProductNames.SelectedItem.Value) != -1)
        {
            this.phImage.Visible = true;
            this.LoadSubCategories();
            this.LoadProduct();
        }
    }

    private void LoadProductName()
    {
        ProcessGetProductNames processGetNames = new ProcessGetProductNames();

        try
        {
            processGetNames.Invoke();
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPage.aspx");
        }

        this.ddlProductNames.DataTextField = "ProductName";
        this.ddlProductNames.DataValueField = "ProductId";
        this.ddlProductNames.DataSource = processGetNames.ResultSet;
        this.ddlProductNames.DataBind();
    }

    private void LoadColour()
    {
        ProcessGetColour processGetColour = new ProcessGetColour();

        try
        {
            processGetColour.Invoke();
        }
        catch
        {
            Response.Redirect("~/ErrorPage.aspx");
        }

        this.ddlColour.DataTextField = "ProductColourName";
        this.ddlColour.DataValueField = "ProductColourId";
        this.ddlColour.DataSource = processGetColour.ResultSet;
        this.ddlColour.DataBind();
    }

    //private void LoadSize()
    //{
    //    ProcessGetSize processGetSize = new ProcessGetSize();

    //    try
    //    {
    //        processGetSize.Invoke();
    //    }
    //    catch
    //    {
    //        Response.Redirect("~/ErrorPage.aspx");
    //    }

    //    this.ddlSize.DataTextField = "ProductSizeName";
    //    this.ddlSize.DataValueField = "ProductSizeId";
    //    this.ddlSize.DataSource = processGetSize.ResultSet;
    //    this.ddlSize.DataBind();
    //}

    private void LoadWeight()
    {
        ProcessGetWeight processGetWeight = new ProcessGetWeight();

        try
        {
            processGetWeight.Invoke();
        }
        catch
        {
            Response.Redirect("~/ErrorPage.aspx");
        }

        this.ddlWeight.DataTextField = "ProductWeightName";
        this.ddlWeight.DataValueField = "ProductWeightId";
        this.ddlWeight.DataSource = processGetWeight.ResultSet;
        this.ddlWeight.DataBind();
    }

	private void LoadCategories()
	{
		ProcessGetProductCategory processGetCategory = new ProcessGetProductCategory();

		try
		{
			processGetCategory.Invoke();
		}
		catch(Exception ex)
		{
			Response.Redirect("~/ErrorPage.aspx");
		}
		
		ddlCategory.DataTextField = "ProductCategoryName";
		ddlCategory.DataValueField = "ProductCategoryID";
		ddlCategory.DataSource = processGetCategory.ResultSet;
		ddlCategory.DataBind();
	}

    private void LoadSubCategories()
    {
        int productId = int.Parse(this.ddlProductNames.SelectedItem.Value);

        if (productId != -1)
        {
            Product prod = new Product();
            prod.ProductId = productId;

            ProcessGetProductByProductId getProduct = new ProcessGetProductByProductId();
            getProduct.Product = prod;
            getProduct.Invoke();

            SubCategory subCategory = new SubCategory();
            subCategory.ProductCategoryId = getProduct.Product.ProductCategoryId;

            ProcessGetSubCategoryByProductCategoryId processGetSubCategory = new ProcessGetSubCategoryByProductCategoryId();
            processGetSubCategory.SubCategory = subCategory;

            try
            {
                processGetSubCategory.Invoke();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/ErrorPage.aspx");
            }

            ddlSubCategory.DataTextField = "SubCategoryDisplayName";
            ddlSubCategory.DataValueField = "SubCategoryId";
            ddlSubCategory.DataSource = processGetSubCategory.ResultSet;
            ddlSubCategory.DataBind();
        }
    }

    private void LoadChangedSubCategories(int categoryId)
    {
        SubCategory subCategory = new SubCategory();
        subCategory.ProductCategoryId = categoryId;

        ProcessGetSubCategoryByProductCategoryId processGetSubCategory = new ProcessGetSubCategoryByProductCategoryId();
        processGetSubCategory.SubCategory = subCategory;

        try
        {
            processGetSubCategory.Invoke();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/ErrorPage.aspx");
        }

        ddlSubCategory.DataTextField = "SubCategoryDisplayName";
        ddlSubCategory.DataValueField = "SubCategoryId";
        ddlSubCategory.DataSource = processGetSubCategory.ResultSet;
        ddlSubCategory.DataBind();
    }

	protected void btnAdd_Click( object sender , EventArgs e )
	{
		if ( IsValid )
		{
			ProcessAddProduct addProduct = new ProcessAddProduct();
			Product prod = new Product();

            Dictionary<string, int> stockLevels = new Dictionary<string, int>();
            stockLevels.Add(SizeConstants.Small, int.Parse(this.txtSmall.Text));
            stockLevels.Add(SizeConstants.Medium, int.Parse(this.txtMedium.Text));
            stockLevels.Add(SizeConstants.Large, int.Parse(this.txtLarge.Text));

            prod.ProductCategoryId = int.Parse(this.ddlCategory.SelectedItem.Value);
            prod.SubCategoryId = int.Parse(this.ddlSubCategory.SelectedItem.Value);
            prod.ProductWeightId = int.Parse(this.ddlWeight.SelectedItem.Value);
            //prod.ProductSizeId = int.Parse(this.ddlSize.SelectedItem.Value);
            prod.ProductColourId = int.Parse(this.ddlColour.SelectedItem.Value);
            prod.Name = this.txtProductName.Text.Trim();
            prod.Description = this.txtDescription.Text;
            //need to add product image url
			//prod.ImageData = fileUploadImage.FileBytes;
            prod.ImageUrl = this.fileUploadImage.FileName;
            prod.Price = Convert.ToDecimal(this.txtPrice.Text);
            //prod.StockLevel = int.Parse(this.txtStockLevel.Text);
            addProduct.StockLevels = stockLevels;
			addProduct.Product = prod;

			try
			{
				addProduct.Invoke();
			}
			catch(Exception ex)
			{
				Response.Write(ex);
			}
			
			Response.Redirect( "Products.aspx" );
		}
	}

    private void LoadProduct()
    {
        Product prod = new Product();
        prod.ProductId = int.Parse(this.ddlProductNames.SelectedItem.Value);

        ProcessGetProductByProductId getProduct = new ProcessGetProductByProductId();
        getProduct.Product = prod;

        try
        {
            getProduct.Invoke();

            this.txtProductName.Text = getProduct.Product.Name;
            this.txtDescription.Text = getProduct.Product.Description;
            this.txtPrice.Text = getProduct.Product.Price.ToString();
            this.imgProductDetail.ImageUrl = "../Images/catalogue/small/" + getProduct.Product.ImageUrl.ToString();
            this.ddlCategory.SelectedIndex = this.ddlCategory.Items.IndexOf(this.ddlCategory.Items.FindByText(getProduct.Product.ProductCategory.ProductCategoryName));
            this.ddlSubCategory.SelectedIndex = this.ddlSubCategory.Items.IndexOf(this.ddlSubCategory.Items.FindByText(getProduct.Product.SubCategory.SubCategoryDisplayName));
            this.ddlColour.SelectedIndex = this.ddlColour.Items.IndexOf(this.ddlColour.Items.FindByText(getProduct.Product.ProductColour.ProductColourName));
            //this.ddlSize.SelectedIndex = this.ddlSize.Items.IndexOf(this.ddlSize.Items.FindByText(getProduct.Product.ProductSize.ProductSizeName));
            this.ddlWeight.SelectedIndex = this.ddlWeight.Items.IndexOf(this.ddlWeight.Items.FindByText(getProduct.Product.ProductWeight.ProductWeightName));
            // Save product image Id in case user does not want to update image.
            SavedProductImageUrl = getProduct.Product.ImageUrl;
            SavedProductImageId = getProduct.Product.ImageId;
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

	protected void btnCancel_Click( object sender , EventArgs e )
	{
		Response.Redirect( "Products.aspx" );
	}

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlCategory.SelectedIndex != 0)
        {
            int categoryId = int.Parse(this.ddlCategory.SelectedItem.Value);
            this.LoadChangedSubCategories(categoryId);
        }
    }
}
