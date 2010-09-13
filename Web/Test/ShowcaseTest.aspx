<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowcaseTest.aspx.cs" Inherits="Test_ShowcaseTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:repeater id="rptShowcase" runat="server" onitemdatabound="rptShowcase_OnItemDataBound">
            <itemtemplate>
                <asp:checkbox id="chkProduct" runat="server" />
            </itemtemplate>
        </asp:repeater>
    </div>
    <div>
        <asp:button id="btnAdd" text="Add" runat="server" onclick="btnAdd_Click" />
    </div>
    </form>
</body>
</html>
