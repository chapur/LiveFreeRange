<%@ Page Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="Admin_EditProduct" Title="Admin Control Panel | Edit Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderAdmin" Runat="Server">
<table cellSpacing="0" cellPadding="0" width="100%" border="0" style="height: 362px">
            <tr>
                <td colSpan="2">
                    
                </td>
            </tr>
            <tr>
                <td vAlign="top" style="width: 21px">

                </td>
                <td vAlign="top" align="left">
                    <table height="100%" cellSpacing="0" cellPadding="0" width="620" align="left" border="0">
                        <tr vAlign="top">
                            <td>
                                <br>
                                &nbsp;<table cellSpacing="0" cellPadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="ContentHead" style="width: 60px; height: 13px">
                                            Name:</td>
                                        <td class="ContentHead" style="height: 13px">
                                            <asp:TextBox id="txtName" runat="server" CssClass="textField"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="requireName" runat="server" ErrorMessage="Product name required." ControlToValidate="txtName" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td class="ContentHead" style="width: 60px">
                                            Description:
                                        </td>
                                        <td class="ContentHead">
                                            <asp:TextBox id="txtDescription" runat="server" Height="104px" TextMode="MultiLine"
                                                Width="352px" CssClass="textField"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="ContentHead" style="width: 60px; height: 24px;">
                                            Price:</td>
                                        <td class="ContentHead" style="height: 24px">
                                            <asp:TextBox id="txtPrice" runat="server" CssClass="textField"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="requirePrice" runat="server" ErrorMessage="Price Required." ControlToValidate="txtPrice" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td class="ContentHead" style="width: 60px">
                                            Category:</td>
                                        <td class="ContentHead">
                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="textField" onselectedindexchanged="ddlCategory_SelectedIndexChanged" autopostback="true">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="ContentHead" style="width: 60px">
                                            Sub-Category:</td>
                                        <td class="ContentHead">
                                            <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="textField">
                                            </asp:DropDownList></td>
                                    </tr>
                                     <tr>
                                        <td class="ContentHead" style="width: 60px">
                                            Colour:</td>
                                        <td class="ContentHead">
                                            <asp:DropDownList ID="ddlColour" runat="server" CssClass="textField">
                                            </asp:DropDownList></td>
                                    </tr>
                               
                                     <tr>
                                        <td class="ContentHead" style="width: 60px">
                                            Weight:</td>
                                        <td class="ContentHead">
                                            <asp:DropDownList ID="ddlWeight" runat="server" CssClass="textField">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                            Small:</td>
                                        <td style="width: 100px">
                                            <asp:textbox id="txtSmall" runat="server" CssClass="textField" columns="4">
                                            </asp:textbox></td>
                                    </tr>
                                            <tr>
                                        <td style="width: 100px">
                                            Medium:</td>
                                        <td style="width: 100px">
                                            <asp:textbox id="txtMedium" runat="server" CssClass="textField" columns="4">
                                            </asp:textbox></td>
                                    </tr>
                                            <tr>
                                        <td style="width: 100px">
                                            Large:</td>
                                        <td style="width: 100px">
                                            <asp:textbox id="txtLarge" runat="server" CssClass="textField" columns="4">
                                            </asp:textbox></td>
                                    </tr>
                                    <tr>
                                        <td class="ContentHead" style="width: 60px">
                                            Image:</td>
                                        <td class="ContentHead">
                                            <asp:Image ID="imgProductDetail" runat="server" BorderColor="#92775C" BorderStyle="Double"
                                                BorderWidth="3px" Width="100px" /></td>
                                    </tr>
                                    <!--non-visible literal to hold image id so we can use it during update.-->
                                    <asp:literal id="litImageId" visible="false" runat="server" />
                                    <tr>
                                        <td class="ContentHead" style="width: 60px">
                                        </td>
                                        <td class="ContentHead">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ContentHead" style="width: 60px">
                                        </td>
                                        <td class="ContentHead">
                                            <asp:FileUpload id="fileUploadImage" runat="server" Width="320px" CssClass="textField" /></td>
                                    </tr>
                                </table>
                                <table cellSpacing="0" cellPadding="0" width="100%" border="0" valign="top">
                                    <tr>
                                        <td rowspan="1" style="width: 4px">
                                            &nbsp;
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 120px">
                                                <tr>
                                                    <td style="width: 59px">
                                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" CssClass="button" /></td>
                                                    <td style="width: 59px">
                                                    </td>
                                                    <td style="width: 100px">
                                                        <asp:Button
                                                ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="button" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
</asp:Content>

