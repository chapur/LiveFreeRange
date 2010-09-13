<%@ Page Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="Admin_OrderDetails" Title="Admin Control Panel | Order Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderAdmin" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="75%">
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Transaction ID</td>
            <td>
                <asp:literal ID="litTransactionID" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Purchased Items:</td>
            <td>
                <asp:GridView ID="gvOrderDetailsProducts" runat="server" AutoGenerateColumns="false">
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
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Shipped Date:</td>
            <td>
                <asp:TextBox ID="txtShippedDate" runat="server" CssClass="textField"></asp:TextBox>
                <asp:ImageButton ID="imagebuttonDatePicker" runat="server" ImageUrl="~/Images/icon-calendar.gif"
                    OnClick="imagebuttonDatePicker_Click" />
                <asp:Calendar ID="calendarDatePicker" runat="server" OnSelectionChanged="calendarDatePicker_SelectionChanged"
                    Visible="False" Width="128px"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Tracking Number:</td>
            <td>
                <asp:TextBox ID="txtTrackingNumber" runat="server" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Order Status:</td>
            <td>
                <asp:DropDownList ID="ddlOrderStatus" runat="server" CssClass="textField">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 224px">
                    <tr>
                        <td style="width: 59px">
                <asp:Button ID="btnReturn" runat="server" Text="Return" CssClass="button" OnClick="btnReturn_Click" /></td>
                        <td style="width: 62px">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="button" /></td>
                        <td style="width: 100px">
                <asp:Button ID="btnRefund" runat="server" Text="Issue Refund" OnClick="btnRefund_Click" CssClass="button" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

