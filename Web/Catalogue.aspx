<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Catalogue.aspx.cs" Inherits="Catalogue" masterpagefile="~/MasterPages/MasterPage.master"%>
<%@ register tagname="ucShowcase" tagprefix="uc" src="~/UserControls/Showcase.ascx" %>
<%@ register tagname="ucProductList" tagprefix="uc" src="~/UserControls/ProductList.ascx" %>
<asp:content contentplaceholderid="cphMain" runat="server">
     <table>
         <tr>
            <asp:datalist id="dlLinks" runat="server">
            <itemtemplate>
                 <td><%#Eval("SubCategoryDisplayName") %></td>
            </itemtemplate>
            </asp:datalist>
        </tr>
    </table>
    <div>
        <uc:ucproductlist id="ucProductList" runat="server" />
    </div>
</asp:content>
