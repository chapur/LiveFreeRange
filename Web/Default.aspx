<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" masterpagefile="~/MasterPages/Cambodian.master"%>
<%@ register tagprefix="uc" tagname="ucHomepageShowcase" src="~/UserControls/HomepageShowcase.ascx" %>
<%@ register tagprefix="uc" tagname="ucNavigation" src="~/UserControls/Navigation.ascx" %>
<%@ register tagprefix="uc" tagname="ucTwitter" src="~/UserControls/Twitter.ascx" %>
<asp:content contentplaceholderid="cphMain" runat="server">
    <uc:uchomepageshowcase id="ucHomepageShowcase" runat="server" />
    <uc:uctwitter id="ucTwitter" runat="server" />
</asp:content>

