using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Test_ShowcaseTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int[] myArray = { 1, 2, 3, 4, 5 };
        this.rptShowcase.DataSource = myArray;
        this.rptShowcase.DataBind();
    }

    protected void rptShowcase_OnItemDataBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView row = e.Item.DataItem as DataRowView;
            CheckBox chkProduct = e.Item.FindControl("chkProduct") as CheckBox;
            chkProduct.Attributes.Add("internalid", "attvalue");
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem oItem in rptShowcase.Items)
        {
            CheckBox chkProduct = oItem.FindControl("chkProduct") as CheckBox;
            if (chkProduct.Checked)
            {
                int id = Convert.ToInt32(chkProduct.Attributes["internalid"]);
            }
        } 

    }
}
