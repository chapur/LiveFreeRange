using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;
using System.Data;

public partial class Admin_Showcase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LoadShowcase();
        }
    }

    private void LoadShowcase()
    {
        ProcessGetShowcaseByPageId processShowcase = new ProcessGetShowcaseByPageId();
        processShowcase.PageId = Convert.ToInt32(Request.QueryString["page"]);

        try
        {
            processShowcase.Invoke();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/ErrorPage.aspx");
        }
     
        this.LoadProducts(processShowcase.ResultSet);
    }

    private void LoadProducts(DataSet resultSet)
    {
        DataSet products = null;
        Collection<DataSet> ds = new Collection<DataSet>();

        foreach (DataRow dr in resultSet.Tables[0].Rows)
        {
            ProcessGetProductsByIntId processProducts = new ProcessGetProductsByIntId();
            processProducts.ProductId = Convert.ToInt32(dr[0]);
            processProducts.Invoke();
            ds.Add(processProducts.ResultSet);
        }

        this.datalistProducts.DataSource = ds;
        this.datalistProducts.DataBind();
    }

    protected void Products_OnItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataSet ds = (DataSet)e.Item.DataItem;

        Image imgProduct = e.Item.FindControl("imgProduct") as Image;
        imgProduct.ImageUrl = "../Images/catalogue/small/" + ds.Tables[0].Rows[0]["ProductImageUrl"].ToString();

        HyperLink hlProductName = e.Item.FindControl("hlProductName") as HyperLink;
        hlProductName.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();

        Literal litDescription = e.Item.FindControl("litDescription") as Literal;
        litDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

        Literal litPrice = e.Item.FindControl("litPrice") as Literal;
        litPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();

        //Literal litCategory = e.Item.FindControl("litCategory") as Literal;
        //litCategory.Text = ds.Tables[0].Rows[0]["ProductCategory"].ToString() + " - " + ds.Tables[0].Rows[0]["SubCategory"].ToString();

    }
}
