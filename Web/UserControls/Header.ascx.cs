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

public partial class UserControls_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.hlClothing.NavigateUrl = "~/Catalogue.aspx?CategoryId=1";
        this.hlJewellery.NavigateUrl = "~/Catalogue.aspx?CategoryId=2";
        this.hlGifts.NavigateUrl = "~/Catalogue.aspx?CategoryId=3";
    }
}
