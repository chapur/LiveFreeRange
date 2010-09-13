using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteMap.SiteMapResolve += new SiteMapResolveEventHandler(AppendQueryString);
    }

    private SiteMapNode AppendQueryString(object sender, SiteMapResolveEventArgs e)
    {
        if (SiteMap.CurrentNode != null)
        {
            SiteMapNode temp = SiteMap.CurrentNode.Clone(true);
            Uri u = new Uri(e.Context.Request.Url.ToString());
            temp.Url = temp.Url + u.Query;
            if (temp.ParentNode != null)
                temp.ParentNode.Url = temp.ParentNode.Url + u.Query;
            return temp;
        }
        else
            return null;
    }
}
