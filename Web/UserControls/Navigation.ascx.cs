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
using LiveFreeRange.Operational;

public partial class UserControls_Navigation : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.hlMen.Text = CategoryConstants.Clothing;
        this.hlMen.NavigateUrl = "~/Catalogue.aspx?CategoryId=1";
        this.hlWomen.Text = CategoryConstants.Jewellery;
        this.hlWomen.NavigateUrl = "~/Catalogue.aspx?CategoryId=2";
        this.hlKids.Text = CategoryConstants.Gifts;
        this.hlKids.NavigateUrl = "~/Catalogue.aspx?CategoryId=3";
    }
}
