<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" masterpagefile="~/MasterPages/Cambodian.master"%>
<asp:content contentplaceholderid="cphMain" runat="server">
<table border="0" cellpadding="2" cellspacing="0" style="width: 432px">
        <tr>
            <td style="width: 23px"><img src="images/spacer.gif" width="1" height="8" /></td>
        </tr>
        <tr>
            <td style="width: 23px"><img src="images/spacer.gif" width="50" height="1" /></td>
            <td style="width: 167px">Firstname:</td>
            <td><asp:TextBox id="txtFirstname" runat="server" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredFirstname" runat="server" ControlToValidate="txtFirstname"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Firstname required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Lastname:</td>
            <td><asp:TextBox id="txtLastname" runat="server" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredLastname" runat="server" ControlToValidate="txtLastname"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Lastname required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Address:</td>
            <td><asp:TextBox id="txtAddress" runat="server" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredAddress" runat="server" ControlToValidate="txtAddress"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Address required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Address 2:</td>
            <td><asp:TextBox id="txtAddress2" runat="server" Width="176px" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">City:</td>
            <td><asp:TextBox id="txtCity" runat="server" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredCity" runat="server" ControlToValidate="txtCity"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="City required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">State:</td>
            <td><asp:TextBox id="txtState" runat="server" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredState" runat="server" ControlToValidate="txtState"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="State required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Postal Code:</td>
            <td><asp:TextBox id="txtPostalCode" runat="server" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredPostalCode" runat="server" ControlToValidate="txtPostalCode"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Postal Code required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Password:</td>
            <td><asp:TextBox id="txtPassword" runat="server" TextMode="Password" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredPassword" runat="server" ControlToValidate="txtPassword"
                    Display="Dynamic" ErrorMessage="Password required." Width="152px" EnableClientScript="False"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="comparePasswords" runat="server" Display="Dynamic" EnableClientScript="False"
                    ErrorMessage="The passwords entered do not match" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Width="240px"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Confirm Password:</td>
            <td><asp:TextBox id="txtConfirmPassword" runat="server" TextMode="Password" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Confirm password required."
                    Width="176px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Email:</td>
            <td><asp:TextBox id="txtEmail" runat="server" TextMode="singleLine" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredEmail" runat="server" ControlToValidate="txtEmail"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Email required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Phone:</td>
            <td><asp:TextBox id="txtPhone" runat="server" Width="176px" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Phone 2:</td>
            <td><asp:TextBox id="txtPhone2" runat="server" Width="176px" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Fax:</td>
            <td><asp:TextBox id="txtFax" runat="server" Width="176px" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Subscribe to Newsletter:</td>
            <td><asp:CheckBox id="chkNewsletter" runat="server" Width="176px" CssClass="textField" /></td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td><asp:Button ID="btnRegister" runat="server" Text="Register Account" OnClick="btnRegister_Click" CssClass="button" /></td>
        </tr>
    </table>
</asp:content>