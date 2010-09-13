<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Showcase.aspx.cs" Inherits="Admin_Showcase" masterpagefile="~/MasterPages/Admin.master"%>
<asp:content contentplaceholderid="contentplaceholderAdmin" runat="server">
    <a href="AddShowcase.aspx">Add Showcase</a>
    <asp:DataList Id="datalistProducts" onitemdatabound="Products_OnItemDataBound" runat="server" RepeatColumns="1" WIdth="100%">
        <ItemTemplate>
            <table border="0" cellpadding="1" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <img border="0" height="1" src="../images/spacer.gif" width="50" /></td>
                    <td align="right" valign="top">
                         <asp:image cssclass="prodBorder" height="85" borderwidth="0" id="imgProduct" runat="server" />
                    </td>
                    <td valign="top" width="100%">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="17">
                                    <img border="0" height="3" src="../images/spacer.gif" width="17" /></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td class="ProductListHead">
                                    <asp:hyperlink id="hlProductName" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img border="0" height="5" src="../images/spacer.gif" width="1" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table border="0" cellpadding="0" cellspacing="0" width="75%">
                                        <tr>
                                            <td class="prodUnderlineBG" width="100%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img border="0" height="1" src="../images/spacer.gif" width="1" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="../images/prodDecorRight.gif" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:literal id="litDescription" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img border="0" height="5" src="../images/spacer.gif" width="1" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <span class="ProductListItem"><b>Price: </b>
                                        <asp:literal id="litPrice" runat="server" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img border="0" height="5" src="../images/spacer.gif" width="1" /></td>
                            </tr>
                                  <tr>
                                <td>
                                </td>
                                <td>
                                    <span class="ProductListItem"><b>Category: </b>
                                         <asp:literal id="litCategory" runat="server" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img border="0" height="5" src="../images/spacer.gif" width="1" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                
                            </tr>
                        </table>
                    </td>
                    <td>
                        <img border="0" height="1" src="../images/spacer.gif" width="15" /></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:content>