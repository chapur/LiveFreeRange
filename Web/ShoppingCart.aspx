<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" Title="Little Italy Vineyard | Shopping Cart" %>

<asp:Content id="Content1" ContentPlaceHolderid="cphMain" Runat="Server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 11px"><img src="images/spacer.gif" width="10" height="15" /></td>
            <td width="100%"></td>
            <td><img src="images/spacer.gif" width="10" height="1" /></td>
        </tr>
        <tr>
            <td style="width: 11px"></td>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="16%" align="center"><b>Remove</b></td>
                        <td width="30%"><b>Product</b></td>
                        <td width="17%" align="center"><b>Quantity</b></td>
                        <td width="18%" align="center"><b>Unit Cost</b></td>
                        <td width="19%" align="center"><b>Subtotal</b></td>
                    </tr>                    
                </table>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 11px"></td>
            <td class="prodUnderlineBG" width="100%"><img src="images/spacer.gif" width="1" height="4" /></td>
            <td></td>
        </tr>
        <tr><td style="width: 11px"><img src="images/spacer.gif" width="1" height="3" /></td></tr>
        <tr>
            <td style="width: 11px"></td>
            <td>
                <asp:GridView id="gvShoppingCart" runat="server" AutoGenerateColumns="false" DataKeyNames="Quantity,ShoppingCartID"
                    OnRowDataBound="gvShoppingCart_RowDataBound" Width="100%" BorderWidth="0px" CellPadding="2" ShowHeader="false">
                <Columns>
                <asp:TemplateField ItemStyle-Width="16%" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <asp:CheckBox id="chkDelete" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="30%">
                    <ItemTemplate>
                        <img src="/web/images/catalogue/small/<%#Eval("ProductImageUrl") %>" alt="Product image" height="50" width="50" /><br />
                         <%# Eval("ProductName")%> - <%# Eval("ProductSizeName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="17%" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <asp:TextBox id="txtQuantity" runat="server" Columns="4" MaxLength="3" Text='<%# Eval("Quantity") %>' width="30px" CssClass="textfield" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="18%" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <%# Eval( "UnitPrice" , "{0:c}" )%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="19%" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <%# Eval( "TotalPrice" , "{0:c}" )%>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                </asp:GridView>
            </td>
            <td></td>
        </tr>
        <tr><td style="width: 11px"><img src="images/spacer.gif" width="1" height="3" /></td></tr>
        <tr>
            <td style="width: 11px"></td>
            <td class="prodUnderlineBG" width="100%"><img src="images/spacer.gif" width="1" height="1" /></td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 11px"></td>
            <td class="prodUnderlineBG" width="100%"><img src="images/spacer.gif" width="1" height="2" /></td>
            <td></td>
        </tr>
        <tr><td style="width: 11px"><img src="images/spacer.gif" width="1" height="5" /></td></tr>
        <tr>
            <td style="width: 11px"></td>
            <td align="right">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td><b>Total:</b></td>
                        <td style="width: 83px;" align="center"><asp:literal id="litTotal" runat="server"></asp:literal></td>
                    </tr>
                </table>
            </td>
            <td></td>
        </tr>
        <tr><td style="width: 11px"><img src="images/spacer.gif" width="1" height="20" /></td></tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td align="right" style="text-align: center">
                <asp:Panel id="pnlPromotion" runat="server" Height="50px" Visible="False" Width="85%">
                Customer's have also purchased the following:<br />
                    <br />
                <asp:GridView id="gvAssociated" runat="server" ShowHeader="False" Width="100%" AutoGenerateColumns="false">
                <Columns>
                <asp:TemplateField>
                 <ItemTemplate>
                  <a href="ProductDetails.aspx?ProductID=<%# Eval("ProductId")%>"><%# Eval("ProductName") %></a>
                 </ItemTemplate>
                    <ItemStyle Width="30%" />
                </asp:TemplateField>
                <asp:TemplateField>
                 <ItemTemplate>
                    <%# Eval("Description") %>
                 </ItemTemplate>
                    <ItemStyle Width="70%" />
                </asp:TemplateField>
                </Columns>
                </asp:GridView>
                </asp:Panel>
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 11px; height: 22px"></td>
            <td align="right" style="height: 22px">
                <asp:Button id="btnContinueShopping" runat="server" OnClick="btnContinueShopping_Click" Text="Continue Shopping" CssClass="button" Width="136px" />
                <img src="images/spacer.gif" width="5" height="1" />
                <asp:Button id="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" CssClass="button" />
                <img src="images/spacer.gif" width="5" height="1" />
                <asp:Button id="btnCheckout" runat="server" OnClick="btnCheckout_Click" Text="Check Out" CssClass="button" />
                <img src="images/spacer.gif" width="15" height="1" />
            </td>
            <td style="height: 22px"></td>
        </tr>
        <tr><td style="width: 11px"><img src="images/spacer.gif" width="1" height="15" /></td></tr>
    </table>
</asp:Content>

