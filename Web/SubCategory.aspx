<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubCategory.aspx.cs" Inherits="SubCategory" masterpagefile="~/MasterPages/MasterPage.master"%>
<asp:content contentplaceholderid="cphMain" runat="server">
    <asp:datalist id="dlProducts" runat="server" onitemdatabound="dlProducts_OnItemDataBound">
        <itemtemplate>
            <div>
                <asp:literal id="litName" runat="server" />
            </div>
            <div>
                <asp:literal id="litColour" runat="server" />
            </div>
        </itemtemplate>
    </asp:datalist>
</asp:content>
