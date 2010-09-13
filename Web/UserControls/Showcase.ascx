<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Showcase.ascx.cs" Inherits="UserControls_Showcase" %>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
<div>
    <asp:listview id="lvProducts" runat="server" onitemdatabound="lvProducts_OnItemDataBound">
        <layouttemplate>
            <ul class="productShowcase">
                <asp:placeholder id="itemPlaceholder" runat="server" />
            </ul>
        </layouttemplate>
        <itemtemplate>
            <li>
                <asp:hyperlink id="hlProduct" runat="server">
                     <asp:image id="imgProduct" runat="server" />
                </asp:hyperlink><br />
                <strong><asp:hyperlink id="hlProductName" runat="server" /></strong>
                <asp:literal id="litPrice" runat="server" />
            </li>
        </itemtemplate>
    </asp:listview>
</div>