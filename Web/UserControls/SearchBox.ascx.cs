using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiveFreeRange.Common;
using LiveFreeRange.BusinessLogic;

public partial class UserControls_SearchBox : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtSearch.Focus();
    }
    
    private void SearchProducts(string searchCriteria)
    {
        ProcessGetProductsSearch processSearch = new ProcessGetProductsSearch();
        processSearch.SearchCriteria = searchCriteria;

        try
        {
            processSearch.Invoke();
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPage.aspx");
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.SearchProducts(this.txtSearch.Text);
    }

}
