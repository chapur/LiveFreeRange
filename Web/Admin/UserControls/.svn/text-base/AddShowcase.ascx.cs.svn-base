using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;

public partial class Admin_UserControls_Showcase : System.Web.UI.UserControl
{
    private Product _product;

    public Product Product
    {
        get { return _product; }
        set { _product = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadProducts();
        }
    }

    ProcessAddShowcase processShowcase = new ProcessAddShowcase();

    private void LoadProducts()
    {
        ProcessGetProducts processProducts = new ProcessGetProducts();

        try
        {
            processProducts.Invoke();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/ErrorPage.aspx");
        }

        this.rptProducts.DataSource = processProducts.ResultSet;
        this.rptProducts.DataBind();
    }

    protected void rptProducts_OnItemDataBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView row = e.Item.DataItem as DataRowView;
            CheckBox chkProduct = e.Item.FindControl("chkProduct") as CheckBox;
            chkProduct.Attributes.Add("internalid", row["ProductId"].ToString());
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem oItem in rptProducts.Items)
        {
            CheckBox chkProduct = oItem.FindControl("chkProduct") as CheckBox;
            int myId = Convert.ToInt32(chkProduct.Attributes["internalid"]);

            if (chkProduct.Checked)
            {
                processShowcase.PageId = Convert.ToInt32(this.ddlPage.SelectedValue);
                processShowcase.ProductId = Convert.ToInt32(chkProduct.Attributes["internalid"]);

                try
                {
                    processShowcase.Invoke();
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/ErrorPage.aspx");
                }
            }
        }
    }
}
