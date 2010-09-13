<%@ Page Language="C#" title="LiveFreeRange | Contact Us" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" masterpagefile="~/MasterPages/MasterPage.master"%>

<asp:content contentplaceholderid="cphMain" runat="server">
    <div>
        <asp:literal id="litName" runat="server"/>
        <asp:textbox id="txtName" runat="server"/>
    </div>
    <div>
        <asp:literal id="litEmail" runat="server" />
        <asp:textbox id="txtEmail" runat="server" />
    </div>
    <div>
        <asp:literal id="litComment" runat="server" />
        <asp:textbox id="txtComment" runat="server" />
    </div>
    <div>
        <asp:button id="btnReset" runat="server" onclick="btnReset_Click" />
        <asp:button id="btnSend" runat="server" onclick="btnSend_Click"/>
    </div>
</asp:content>
