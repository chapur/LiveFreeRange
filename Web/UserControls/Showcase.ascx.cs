using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LiveFreeRange.BusinessLogic;

public partial class UserControls_Showcase : System.Web.UI.UserControl
{
    private int _pageId;

    public int PageId
    {
        get { return _pageId; }
        set { _pageId = value; }
    }

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
        processShowcase.PageId = this.PageId;

        try
        {
            processShowcase.Invoke();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }

        this.LoadProducts(processShowcase.ResultSet);
    }

    private void LoadProducts(DataSet resultSet)
    {
        Collection<DataSet> ds = new Collection<DataSet>();

        foreach (DataRow dr in resultSet.Tables[0].Rows)
        {
            ProcessGetProductsByIntId processProducts = new ProcessGetProductsByIntId();
            processProducts.ProductId = Convert.ToInt32(dr[0]);
            processProducts.Invoke();
            ds.Add(processProducts.ResultSet);
        }

        this.lvProducts.DataSource = ds;
        this.lvProducts.DataBind();
    }

    protected void lvProducts_OnItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem listViewDataItem = e.Item as ListViewDataItem;
        DataSet ds = listViewDataItem.DataItem as DataSet;
        
        Image imgProduct = e.Item.FindControl("imgProduct") as Image;
        imgProduct.ImageUrl = "../Images/catalogue/small/" + ds.Tables[0].Rows[0]["ProductImageUrl"].ToString();

        HyperLink hlProductName = e.Item.FindControl("hlProductName") as HyperLink;
        hlProductName.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();

        HyperLink hlProduct = e.Item.FindControl("hlProduct") as HyperLink;
        hlProduct.NavigateUrl = "/Web/ProductDetails.aspx?ProductId=" + ds.Tables[0].Rows[0]["ProductId"].ToString() + "&CategoryId=" + ds.Tables[0].Rows[0]["ProductCategoryId"].ToString();

        Literal litPrice = e.Item.FindControl("litPrice") as Literal;
        litPrice.Text = string.Format("{0:c}", ds.Tables[0].Rows[0]["Price"]);

    }
}
