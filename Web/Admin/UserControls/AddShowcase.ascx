<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddShowcase.ascx.cs" Inherits="Admin_UserControls_Showcase" %>
<div>
    <div>
        <asp:dropdownlist id="ddlPage" runat="server" >
            <asp:listitem value="0" selected="True" text="Homepage" />
            <asp:listitem value="1" text="Men's storepage" />
            <asp:listitem value="2" text="Women's storepage" />
            <asp:listitem value="3" text="Kid's storepage" />
        </asp:dropdownlist>
    </div>
    <div>
    <asp:repeater id="rptProducts" runat="server" onitemdatabound="rptProducts_OnItemDataBound">
        <itemtemplate>
            <div>
                <img alt="" border="0" class="prodBorder" height="85" src='../Images/catalogue/small/<%# Eval("ProductImageUrl") %>'>
                <asp:checkbox id="chkProduct" runat="server" />
            </div>
        </itemtemplate>
    </asp:repeater>
    </div>
    <div><asp:button id="btnAdd" runat="server" text="Add showcase" onclick="btnAdd_Click" /></div>
</div>