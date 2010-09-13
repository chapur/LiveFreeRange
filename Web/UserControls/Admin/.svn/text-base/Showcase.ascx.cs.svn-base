using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;

public partial class UserControls_Admin_Showcase : System.Web.UI.UserControl
{
    private Product _product;

    public Product Product
    {
        get { return _product; }
        set { _product = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.LoadProducts();    
    }

    private void LoadProducts()
    {
        ProcessGetProducts processProducts = new ProcessGetProducts();

        try
        {
            processProducts.Invoke();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }

        this.rptProducts.DataSource = processProducts.ResultSet;
        this.rptProducts.DataBind();
    }

    protected void rptProducts_OnItemDatabound(object sender, RepeaterItemEventArgs e)
    { 
        
    }
}
