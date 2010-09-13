<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" masterpagefile="~/MasterPages/Cambodian.master"%>
<%@ register tagprefix="uc" tagname="ProductDetails" src="~/UserControls/ProductDetailsNew.ascx" %>
<asp:content contentplaceholderid="cphMain" runat="server">
    <uc:productdetails id="ucProductDetails" runat="server" />
</asp:content>