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

using LiveFreeRange.BusinessLogic;
using LiveFreeRange.Common;
using LiveFreeRange.Operational;

public partial class Admin_EditProduct : System.Web.UI.Page
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
			this.txtName.Focus();
			this.LoadCategories();
            this.LoadSubCategories();
            this.LoadColour();
            //this.LoadSize();
            this.LoadWeight();
			this.LoadProduct();
		}
	}

	private void LoadCategories()
	{
		ProcessGetProductCategory processGetCategory = new ProcessGetProductCategory();

		try
		{
			processGetCategory.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
		
		ddlCategory.DataTextField = "ProductCategoryName";
		ddlCategory.DataValueField = "ProductCategoryId";
		ddlCategory.DataSource = processGetCategory.ResultSet;
		ddlCategory.DataBind();
	}

    private void LoadSubCategories()
    {
        Product prod = new Product();
        prod.ProductId = int.Parse(Request.QueryString["ProductId"]);

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

    private void LoadColour()
    {
        ProcessGetColour processGetColour = new ProcessGetColour();

        try
        {
            processGetColour.Invoke();
        }
        catch(Exception ex)
        {
            Response.Write(ex);
        }

        ddlColour.DataTextField = "ProductColourName";
        ddlColour.DataValueField = "ProductColourId";
        ddlColour.DataSource = processGetColour.ResultSet;
        ddlColour.DataBind();
    }

    //private void LoadSize()
    //{
    //    ProcessGetSize processGetSize = new ProcessGetSize();

    //    try
    //    {
    //        processGetSize.Invoke();
    //    }
    //    catch(Exception ex)
    //    {
    //        Response.Write(ex);
    //    }

    //    ddlSize.DataTextField = "ProductSizeName";
    //    ddlSize.DataValueField = "ProductSizeId";
    //    ddlSize.DataSource = processGetSize.ResultSet;
    //    ddlSize.DataBind();
    //}

    private void LoadWeight()
    {
        ProcessGetWeight processGetWeight = new ProcessGetWeight();

        try
        {
            processGetWeight.Invoke();
        }
        catch(Exception ex)
        {
            Response.Write(ex);
        }

        ddlWeight.DataTextField = "ProductWeightName";
        ddlWeight.DataValueField = "ProductWeightId";
        ddlWeight.DataSource = processGetWeight.ResultSet;
        ddlWeight.DataBind();
    }

	private void LoadProduct()
	{
		Product prod = new Product();
		prod.ProductId = int.Parse( Request.QueryString["ProductId"] );

		ProcessGetProductByProductId getProduct = new ProcessGetProductByProductId();
		getProduct.Product = prod;

        ProcessGetProductStockLevelById getStockLevel = new ProcessGetProductStockLevelById();
        getStockLevel.ProductId = prod.ProductId;

        try
        {
            getProduct.Invoke();
            getStockLevel.Invoke();


            this.txtName.Text = getProduct.Product.Name;
            this.txtDescription.Text = getProduct.Product.Description;
            this.txtPrice.Text = getProduct.Product.Price.ToString();
            this.imgProductDetail.ImageUrl = "../Images/catalogue/small/" + getProduct.Product.ImageUrl.ToString();
            this.ddlCategory.SelectedIndex = this.ddlCategory.Items.IndexOf(this.ddlCategory.Items.FindByText(getProduct.Product.ProductCategory.ProductCategoryName));
            this.ddlSubCategory.SelectedIndex = this.ddlSubCategory.Items.IndexOf(this.ddlSubCategory.Items.FindByText(getProduct.Product.SubCategory.SubCategoryDisplayName));
            this.ddlColour.SelectedIndex = this.ddlColour.Items.IndexOf(this.ddlColour.Items.FindByText(getProduct.Product.ProductColour.ProductColourName));
            //this.ddlSize.SelectedIndex = this.ddlSize.Items.IndexOf(this.ddlSize.Items.FindByText(getProduct.Product.ProductSize.ProductSizeName));
            this.ddlWeight.SelectedIndex = this.ddlWeight.Items.IndexOf(this.ddlWeight.Items.FindByText(getProduct.Product.ProductWeight.ProductWeightName));
            this.litImageId.Text = getProduct.Product.ImageId.ToString();

            if (getStockLevel.ResultSet.Tables[0].Rows.Count > 0)
                this.txtSmall.Text = getStockLevel.ResultSet.Tables[0].Rows[0]["StockLevel"].ToString();
            else
                this.txtSmall.Text = "0";

            if (getStockLevel.ResultSet.Tables[0].Rows.Count > 1)
                this.txtMedium.Text = getStockLevel.ResultSet.Tables[0].Rows[1]["StockLevel"].ToString();
            else
                this.txtMedium.Text = "0";

            if (getStockLevel.ResultSet.Tables[0].Rows.Count > 2)
                this.txtLarge.Text = getStockLevel.ResultSet.Tables[0].Rows[2]["StockLevel"].ToString();
            else this.txtLarge.Text = "0";

            //this.txtStockLevel.Text = getProduct.Product.StockLevel.ToString();
            // Save product image Id in case user does not want to update image.
            SavedProductImageUrl = getProduct.Product.ImageUrl;
            SavedProductImageId = getProduct.Product.ImageId;
        }
        catch(Exception ex)
        {
            Response.Write(ex);
        }
	}

	protected void btnUpdate_Click( object sender , EventArgs e )
	{
		if ( IsValid )
		{
			Product prod = new Product();
			prod.ProductId = int.Parse( Request.QueryString["ProductId"] );

            Dictionary<string, int> stockLevels = new Dictionary<string, int>();
            stockLevels.Add(SizeConstants.Small, int.Parse(this.txtSmall.Text));
            stockLevels.Add(SizeConstants.Medium, int.Parse(this.txtMedium.Text));
            stockLevels.Add(SizeConstants.Large, int.Parse(this.txtLarge.Text));

			prod.Name = txtName.Text;
			prod.Description = txtDescription.Text;
			prod.Price = Convert.ToDecimal( txtPrice.Text );
			prod.ProductCategoryId = int.Parse( ddlCategory.SelectedItem.Value );
            prod.SubCategoryId = int.Parse(ddlSubCategory.SelectedItem.Value);
            prod.ProductColourId = int.Parse(ddlColour.SelectedItem.Value);
            //prod.ProductSizeId = int.Parse(ddlSize.SelectedItem.Value);
            prod.ProductWeightId = int.Parse(ddlWeight.SelectedItem.Value);
            //prod.StockLevel = int.Parse(this.txtStockLevel.Text);
            prod.ImageUrl = fileUploadImage.FileName;
            prod.ImageId = Convert.ToInt32(this.litImageId.Text);

            if (fileUploadImage.FileName == string.Empty)
            {
                prod.ImageId = this.SavedProductImageId;
            }
            else
            { 
                //need to be able to add a different image, either already in the db or completely new.
            }


			ProcessUpdateProduct processUpdate = new ProcessUpdateProduct();
			processUpdate.Product = prod;
            processUpdate.StockLevels = stockLevels;

			try
			{
				processUpdate.Invoke();
			}
			catch(Exception ex)
			{
				Response.Write(ex);
			}
			
			Response.Redirect( "Products.aspx" );
		}
	}

	protected void btnCancel_Click( object sender , EventArgs e )
	{
		Response.Redirect( "Products.aspx" );
	}

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int categoryId = int.Parse(this.ddlCategory.SelectedItem.Value);
        this.LoadChangedSubCategories(categoryId);
    }

	
}
