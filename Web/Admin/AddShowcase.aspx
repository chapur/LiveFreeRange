<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddShowcase.aspx.cs" Inherits="Admin_AddShowcase" masterpagefile="~/MasterPages/Admin.master"%>
<%@ register tagprefix="uc" tagname="addShowcase" src="~/Admin/UserControls/AddShowcase.ascx" %>
<asp:content contentplaceholderid="contentplaceholderAdmin" runat="server">
    <uc:AddShowcase id="ucAddShowcase" runat="server" />
</asp:content>