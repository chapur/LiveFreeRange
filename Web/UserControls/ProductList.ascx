<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductList.ascx.cs" Inherits="UserControls_ProductList" %>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
<div>
    <asp:listview id="lvProductList" runat="server" onitemdatabound="lvProductList_OnItemDataBound">
        <layouttemplate>
            <ul class="productShowcase">
                <asp:placeholder id="itemPlaceholder" runat="server" />
            </ul>
        </layouttemplate>
        <itemtemplate>
            <li>
                <asp:hyperlink id="hlProduct" runat="server">
                    <asp:image id="imgProduct" runat="server" /><br />
                    <asp:literal id="litProductName" runat="server" />
                </asp:hyperlink>
            </li>
        </itemtemplate>
    </asp:listview>
</div>  