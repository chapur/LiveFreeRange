<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Showcase.ascx.cs" Inherits="UserControls_Admin_Showcase" %>
<div>
    <div>
        <asp:dropdownlist id="ddlPage" runat="server" />
    </div>
    <asp:repeater id="rptProducts" runat="server" onitemdatabound="rptProducts_OnItemDatabound">
        <itemtemplate>
            <div>
                <img alt="" border="0" class="prodBorder" height="85" src='../Images/catalogue/small/<%# Eval("ProductImageUrl") %>'>
                <asp:checkbox id="chkProduct" runat="server" />
            </div>
        </itemtemplate>
    </asp:repeater>
</div>