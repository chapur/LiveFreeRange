<%@ Page Language="C#" MasterPageFile="~/MasterPages/Account.master" AutoEventWireup="true" CodeFile="CustomerOrderDetails.aspx.cs" Inherits="Account_CustomerOrderDetails" Title="Little Italy Vineyards | Order Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="90%">
        <tr>
            <td style="width: 151px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 151px; height: 13px;">
                Transaction ID</td>
            <td style="width: 100px; height: 13px;">
                <asp:literal ID="litTransactionID" runat="server" Text=""></asp:literal></td>
        </tr>
        <tr>
            <td style="width: 151px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 151px">
                Purchased Items:</td>
            <td style="width: 100px">
                <asp:GridView ID="gvOrderDetailsProducts" runat="server" AutoGenerateColumns="false" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Qty.">
                        <ItemTemplate>
                            <%# Eval("Quantity") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <%# Eval("ProductName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <%# Eval( "Price" , "{0:c}" )%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 151px; height: 16px;">
                Tax:</td>
            <td style="width: 100px; height: 16px;">
                <asp:literal ID="litTax" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td style="width: 151px; height: 16px;">
                Order Total:</td>
            <td style="width: 100px; height: 16px;">
                <asp:literal ID="litOrderTotal" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td style="width: 151px; height: 19px">
            </td>
            <td style="width: 100px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 151px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="btnReturn" runat="server" Text="Return" CssClass="button" OnClick="btnReturn_Click" /></td>
        </tr>
    </table>
</asp:Content>

