<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" masterpagefile="~/MasterPages/Admin.master"%>

<asp:content contentplaceholderid="contentplaceholderAdmin" runat="server">
    <div>
        Administrator Control Panel Log in
    </div>
    <div>
        Username:<asp:textbox id="txtUserName" runat="server" text="simonbegg@hotmail.com"/><br />
        <asp:requiredfieldvalidator id="requiredUserName" runat="server" 
        controltovalidate="txtUserName"
        display="Dynamic"
        enableclientscript="false"
        errormessage="Username required" />
    </div>
    <div>
        Password:<asp:textbox id="txtPassword" runat="server" text="password"/><br />
        <asp:requiredfieldvalidator id="requiredPassword" runat="server"
        controltovalidate="txtPassword"
        display="Dynamic"
        enableclientscript="false"
        errormessage="Password required" />
    </div>
    <div>
        <asp:button id="btnSubmit" runat="server" onclick="btnSubmit_Click" text="Login"/>
    </div>
    <div>
        <asp:literal id="litMessage" runat="server" />
    </div>
</asp:content>
