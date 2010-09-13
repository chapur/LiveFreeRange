<%@ Page Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="Admin_AddProduct" Title="Admin Control Panel | Add Product" %>

<asp:content id="Content1" ContentPlaceHolderId="contentplaceholderAdmin" 
    Runat="Server">
    <br />
    <table border="0" cellpadding="0" cellspacing="0" style="width: 432px">
        <tr>
            <td style="width: 100px">
                Product Name:</td>
            <td style="width: 100px">
                <asp:dropdownlist id="ddlProductNames" runat="server" appenddatabounditems="true" autopostback="true" onselectedindexchanged="ddlProductNames_OnIndexChanged">
                    <asp:listitem text="--Select a product--" value="-1" />
                </asp:dropdownlist>
                <asp:textbox id="txtProductName" runat="server" CssClass="textField"></asp:textbox>
                <asp:requiredfieldvalidator id="requireName" runat="server" 
                    ErrorMessage="Product name required." ControlToValidate="txtProductName" 
                    Display="Dynamic" EnableClientScript="False" Width="160px"></asp:requiredfieldvalidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Category:</td>
            <td style="width: 100px">
                <asp:dropdownlist id="ddlCategory" runat="server" CssClass="textField" autopostback="true" appenddatabounditems="true" onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                <asp:listitem text="--Select a category--" />
                </asp:dropdownlist></td>
        </tr>
            <tr>
            <td style="width: 100px">
                Sub-Category:</td>
            <td style="width: 100px">
                <asp:dropdownlist id="ddlSubCategory" runat="server" CssClass="textField">
                </asp:dropdownlist></td>
        </tr>
               <tr>
            <td style="width: 100px">
                Colour:</td>
            <td style="width: 100px">
                <asp:dropdownlist id="ddlColour" runat="server" CssClass="textField">
                </asp:dropdownlist></td>
        </tr>
              
               <tr>
            <td style="width: 100px">
                Weight:</td>
            <td style="width: 100px">
                <asp:dropdownlist id="ddlWeight" runat="server" CssClass="textField">
                </asp:dropdownlist></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Small:</td>
            <td style="width: 100px">
                <asp:textbox id="txtSmall" runat="server" CssClass="textField">
                </asp:textbox></td>
        </tr>
                <tr>
            <td style="width: 100px">
                Medium:</td>
            <td style="width: 100px">
                <asp:textbox id="txtMedium" runat="server" CssClass="textField">
                </asp:textbox></td>
        </tr>
                <tr>
            <td style="width: 100px">
                Large:</td>
            <td style="width: 100px">
                <asp:textbox id="txtLarge" runat="server" CssClass="textField">
                </asp:textbox></td>
        </tr>
        <tr>
            <td style="width: 100%; height: 124px;">Description:
            </td>
            <td style="width: 100%; height: 124px;">
                <asp:textbox id="txtDescription" runat="server" Height="136px" TextMode="MultiLine"
                    Width="100%"></asp:textbox>
                </td>
        </tr>
        <tr>
            <td style="width: 100px">
                Price:</td>
            <td style="width: 100px">
                <asp:textbox id="txtPrice" runat="server" CssClass="textField"></asp:textbox>
                <asp:requiredfieldvalidator id="requirePrice" runat="server" 
                    ErrorMessage="Price required." ControlToValidate="txtPrice" Display="Dynamic" 
                    EnableClientScript="False"></asp:requiredfieldvalidator></td>
        </tr>
        
        <asp:placeholder id="phImage" runat="server" visible="false">
        <tr>
            <td></td>
            <td class="ContentHead">
                <asp:Image ID="imgProductDetail" runat="server" BorderColor="#92775C" BorderStyle="Double" BorderWidth="3px" Width="100px" /></td>
        </tr>
        </asp:placeholder>
        <tr>
            <td style="width: 100px; height: 22px">
                Image:</td>
            <td style="width: 100px; height: 22px">
                <asp:fileupload id="fileUploadImage" runat="server" Width="320px" 
                    CssClass="textField" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                &nbsp;<table border="0" cellpadding="0" cellspacing="0" style="width: 162px">
                    <tr>
                        <td style="width: 101px">
                <asp:button id="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Product" 
                                CssClass="button" />&nbsp;
                        </td>
                        <td style="width: 58px">
                <asp:button id="btnCancel" runat="server" Text="Cancel" CausesValidation="False" 
                                OnClick="btnCancel_Click" CssClass="button" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table> 
</asp:content>

