<%@ Page Language="C#" MasterPageFile="~/MasterPages/Cambodian.master" AutoEventWireup="true" CodeFile="CustomerOrders.aspx.cs" Inherits="Account_CustomerOrders" Title="Little Italy Vineyards | Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="95%">
        <tr>
            <td>
                <strong>My Orders</strong></td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
    <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" Width="100%">
    <Columns>
    <asp:TemplateField HeaderText="Transaction ID">
        <ItemTemplate>
            <a href="CustomerOrderDetails.aspx?TransID=<%# Eval("TransactionID") %>&OrderID=<%# Eval("OrderID") %>"><%# Eval("TransactionID") %></a>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Order Date">
        <ItemTemplate>
            <%# Eval("OrderDate", "{0:d}") %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Status">
        <ItemTemplate>
            <%# Eval("OrderStatusName") %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Ship Date">
        <ItemTemplate>
            <%# Eval("ShipDate", "{0:d}")%>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Tracking Number">
        <ItemTemplate>
            <%# Eval( "TrackingNumber" )%>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

