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
using LiveFreeRange.BusinessLogic;
using LiveFreeRange.Common;

public partial class Catalogue : System.Web.UI.Page
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
            this.ucProductList.ProductCategoryId = Request.QueryString["CategoryId"];
            this.ucProductList.SubCategoryId = Request.QueryString["SubCategoryId"];
        }

        System.Web.UI.HtmlControls.HtmlGenericControl body;
        body = (System.Web.UI.HtmlControls.HtmlGenericControl)this.Master.FindControl("bodyTag");
        body.Attributes.Add("class", "catalog-category-view categorypath-men-shorts-html category-shorts");
    }
}
