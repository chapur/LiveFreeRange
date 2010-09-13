<%@ Page Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Admin_Products" Title="Admin Control Panel | Products" %>

<asp:Content Id="Content1" ContentPlaceHolderId="contentplaceholderAdmin" Runat="Server">
    <br />
    <asp:Button Id="btnAddProduct" runat="server" OnClick="btnAddProduct_Click"
        Text="Add Product" CssClass="button" /><br />
    <br />
    
    <asp:DataList Id="datalistProducts" runat="server" RepeatColumns="2" WIdth="100%">
        <ItemTemplate>
            <table border="0" cellpadding="1" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <img border="0" height="1" src="../images/spacer.gif" width="50" /></td>
                    <td align="right" valign="top">
                        <a href='EditProduct.aspx?productId=<%# Eval("ProductId") %>&ImageId=<%# Eval("ProductImageUrl") %>'>
                            <img border="0" class="prodBorder" height="85" src='../Images/catalogue/small/<%# Eval("ProductImageUrl") %>'>
                        </a>
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
                                    <a href='EditProduct.aspx?productId=<%# Eval("ProductId") %>&ImageId=<%# Eval("ProductImageUrl") %>'><b>
                                        <%# Eval("ProductName") %>
                                    </b></a>
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
                                    <%# Eval("Description") %>
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
                                        <%# Eval("Price", "{0:c}") %>
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
                                         <%#Eval("ProductCategoryName") %> - <%# Eval("SubCategoryDisplayName") %>
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
</asp:Content>

