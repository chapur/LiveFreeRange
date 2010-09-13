<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckOutConfirm.aspx.cs" Inherits="CheckOutConfirm" masterpagefile="~/MasterPages/MasterPage.master" %>
<asp:content contentplaceholderid="cphMain" runat="server">
 <table cellpadding="0" cellspacing="0" border="0" width="95%" align="Center">
        <tr>
            <td><img src="~/images/spacer.gif" width="10" height="15" /></td>
            <td width="100%"></td>
            <td><img src="~/images/spacer.gif" width="10" height="1" /></td>
        </tr>
        
        <tr>
            <td></td>
            <td class="prodUnderlineBG" width="100%"><img src="~/images/spacer.gif" width="1" height="4" /></td>
            <td></td>
        </tr>
        <tr><td><img src="~/images/spacer.gif" width="1" height="3" /></td></tr>
        <tr>
            <td></td>
            <td>
                <asp:GridView id="gvShoppingCart" runat="server" AutoGenerateColumns="false" ShowHeader="true" 
                    Width="100%" DataKeyNames="Quantity,ShoppingCartId,ProductId" BorderWidth="0px">
                    <Columns>
                        
                        <asp:TemplateField ItemStyle-Width="25%" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" HeaderText="Product">
                            <ItemTemplate>
                            <asp:literal id="litProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="center" HeaderText="Quantity">
                            <ItemTemplate>
                            <asp:literal id="litQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="center" HeaderText="Unit Cost">
                            <ItemTemplate>
                            <asp:literal id="litUnitPrice" runat="server" Text='<%# Eval( "UnitPrice" , "{0:c}" )%>'></asp:literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="center" HeaderText="Subtotal">
                            <ItemTemplate>
                                <asp:literal id="litTotalPrice" runat="server" Text='<%# Eval( "TotalPrice" , "{0:c}" )%>'></asp:literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td></td>
        </tr>
        <tr><td><img src="~/images/spacer.gif" width="1" height="3" /></td></tr>
        <tr>
            <td></td>
            <td class="prodUnderlineBG" width="100%"><img src="~/images/spacer.gif" width="1" height="1" /></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td class="prodUnderlineBG" width="100%"><img src="~/images/spacer.gif" width="1" height="2" /></td>
            <td></td>
        </tr>
        <tr><td><img src="~/images/spacer.gif" width="1" height="5" /></td></tr>
        <tr>
            <td></td>
            <td align="right">
                <table border="0" cellpadding="2" cellspacing="0">
                    <tr>
                        <td><b>Subtotal:</b></td>
                        <td><img src="~/images/spacer.gif" width="15" height="1" /></td>
                        <td style="width: 69px;"><asp:literal id="litSubTotal" runat="server"></asp:literal></td>
                    </tr>
                    <tr>
                        <td><b>Tax:</b></td>
                        <td></td>
                        <td><asp:literal id="litTax" runat="server"></asp:literal></td>
                    </tr>
                    <tr>
                        <td><b>Shipping:</b></td>
                        <td></td>
                        <td><asp:literal id="litShippingCost" runat="server"></asp:literal></td>
                    </tr>
                    <tr><td><img src="~/images/spacer.gif" width="1" height="1" /></td></tr>
                    <tr>
                        <td colspan="3" class="prodUnderlineBG"><img src="~/images/spacer.gif" width="1" height="2" /></td>
                    </tr>
                    <tr><td><img src="~/images/spacer.gif" width="1" height="1" /></td></tr>
                    <tr>
                        <td><b>Order Total:</b></td>
                        <td></td>
                        <td><asp:literal id="litTotal" runat="server"></asp:literal></td>
                    </tr>
                </table>
            </td>
            <td></td>
        </tr>
    </table>
    <br />
    <table border="0" cellpadding="0" cellspacing="3" width="90%" align="Center">
    <asp:placeholder id="phCreditCard" runat="server">
        <tr>
            <td colspan="3"><b>Shipping Information</b></td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" class="separatorBG"><img src="~/images/spacer.gif" width="1" height="1" border="0" /></td>
                        <td><img src="~/images/textSeparatorRight.gif" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td><img src="~/images/spacer.gif" width="1" height="3" /></td></tr>
        <tr>
            <td><img src="~/images/spacer.gif" width="10" height="1" /></td>
            <td nowrap="nowrap">First Name:</td>
            <td width="60%"><asp:literal id="litFirstname" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Last Name:</td>
            <td><asp:literal id="litLastname" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td>Address:</td>
            <td><asp:literal id="litAddress" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Address 2:</td>
            <td><asp:literal id="litAddress2" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td>City:</td>
            <td><asp:literal id="litCity" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td>State:</td>
            <td><asp:literal id="litState" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Postal Code:</td>
            <td><asp:literal id="litPostalCode" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Shipping Options:</td>
            <td></td>
        </tr>
        <tr><td><img src="~/images/spacer.gif" width="1" height="15" /></td></tr>
        <tr>
            <td colspan="3"><b>Payment</b></td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" class="separatorBG"><img src="~/images/spacer.gif" width="1" height="1" border="0" /></td>
                        <td><img src="~/images/textSeparatorRight.gif" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td><img src="~/images/spacer.gif" width="1" height="3" /></td></tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Credit Card:</td>
            <td><asp:literal id="litCreditCardType" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Credit Card Number:</td>
            <td><asp:literal id="litCreditCardNumber" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Security Code:</td>
            <td><asp:literal id="litCreditCardSecurityCode" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Expiration Date:</td>
            <td><asp:literal id="litExpirationDate" runat="server"></asp:literal></td>
        </tr>
        <tr><td><img src="~/images/spacer.gif" width="1" height="15" /></td></tr>
        <tr>
            <td colspan="3"><b>Billing Address</b></td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" class="separatorBG"><img src="~/images/spacer.gif" width="1" height="1" border="0" /></td>
                        <td><img src="~/images/textSeparatorRight.gif" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td><img src="~/images/spacer.gif" width="1" height="3" /></td></tr>
        <tr>
            <td></td>
            <td>Address:</td>
            <td><asp:literal id="litBillingAddress" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Address 2:</td>
            <td><asp:literal id="litBillingAddress2" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td>City:</td>
            <td><asp:literal id="litBillingCity" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td>State:</td>
            <td><asp:literal id="litBillingState" runat="server"></asp:literal></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Postal Code:</td>
            <td><asp:literal id="litBillingPostalCode" runat="server"></asp:literal></td>
        </tr>
        <tr><td><img src="~/images/spacer.gif" width="1" height="15" /></td></tr>
        <tr>
            <td colspan="3" align="right">
                <table cellpadding="3" cellspacing="0" border="0">
                    <tr>
                        <td><asp:Button id="btnEdit" runat="server" Text="Edit Information" Width="136px" OnClick="btnEdit_Click" CssClass="button" /></td>
                        <td><asp:Button id="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm Payment" CssClass="button" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td><img src="~/images/spacer.gif" width="1" height="5" /></td></tr>
        </asp:placeholder>
        <asp:placeholder id="phPayPal" runat="server">
            <asp:imagebutton id="ibCompletePaypalOrder" runat="server" imageurl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" borderwidth="0" alternatetext="PayPal" onclick="ibCompletePaypalOrder_Click" />
            <asp:panel id="pnlOrderDeclined" runat="server">
                <asp:label id="lblTransactionFailureMessage" runat="server" />
            </asp:panel>    
        </asp:placeholder>
    </table>
</asp:content>


