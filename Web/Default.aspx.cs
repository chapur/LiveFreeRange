using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiveFreeRange.Operational;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl body;
        body = (System.Web.UI.HtmlControls.HtmlGenericControl)this.Master.FindControl("bodyTag");
        body.Attributes.Add("class", "cms-index-index cms-home");
    }
}
