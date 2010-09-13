<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" masterpagefile="~/MasterPages/Cambodian.master"%>
<%@ register tagprefix="uc" tagname="ucShowcase" src="~/UserControls/Showcase.ascx" %>
<%@ register tagprefix="uc" tagname="ucNavigation" src="~/UserControls/Navigation.ascx" %>
<%@ register tagprefix="uc" tagname="ucTwitter" src="~/UserControls/Twitter.ascx" %>
<asp:content contentplaceholderid="cphMain" runat="server">
    <a href="ShoppingCart.aspx">Shopping cart</a>
    <uc:ucshowcase id="ucShowcase" runat="server" />
    <uc:ucnavigation id="ucNavigation" runat="server" />
    <uc:uctwitter id="ucTwitter" runat="server" />
</asp:content>

