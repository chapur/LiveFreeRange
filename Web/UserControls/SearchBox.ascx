<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchBox.ascx.cs" Inherits="UserControls_SearchBox" %>
<table>
    <tr>
        <td><asp:textbox id="txtSearch" runat="server" /></td>
        <td><asp:button id="btnSearch" runat="server" text="search" onclick="btnSearch_Click" /></td>
    </tr>
</table>