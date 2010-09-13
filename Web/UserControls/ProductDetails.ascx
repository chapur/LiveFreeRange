<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductDetails.ascx.cs" Inherits="UserControls_ProductDetails" %>
<div>
    <asp:image id="imgProduct" runat="server" />
    <asp:literal id="litProductName" runat="server" />
    <asp:literal id="litProductDescription" runat="server" />
    <asp:literal id="litProductCategory" runat="server" />
    <asp:literal id="litPrice" runat="server" />
    <asp:literal id="litError" runat="server" />
    <asp:dropdownlist id="ddlSizes" runat="server" />
    <asp:textbox id="txtQuantity" runat="server" />
</div>
<div>
    <asp:button id="btnAddToCart" runat="server"  onclick="btnAddToBasket_Click"  text="Add to cart"/>
</div>
<div>
    <asp:hyperlink id="hlContinueShopping" runat="server" text="Continue Shopping" />
</div>