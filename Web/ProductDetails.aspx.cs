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
using LiveFreeRange.BusinessLogic;
using LiveFreeRange.Common;

public partial class ProductDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl body;
        body = (System.Web.UI.HtmlControls.HtmlGenericControl)this.Master.FindControl("bodyTag");
        body.Attributes.Add("class", "catalog-product-view product-greenie categorypath-men-shorts-html category-shorts");
    }
}
