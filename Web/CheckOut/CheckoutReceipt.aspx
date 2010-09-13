<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckoutReceipt.aspx.cs" Inherits="CheckoutReceipt" masterpagefile="~/MasterPages/MasterPage.master" %>

<asp:content contentplaceholderid="cphMain" runat="server">
    <div>
        <asp:panel id="pnlSuccess" runat="server" height="100%" width="100%" visible="false">
            <div>
                <img src="Images/Success.gif" alt="success"/>
                Your order has been processed.
            </div>
            <div>
                Transaction ID:<asp:literal id="litTransactionId" runat="server" /><br />
                Order Total:<asp:literal id="litOrderTotal" runat="server" />
            </div>
        </asp:panel>
        <asp:panel id="pnlFailure" runat="server" height="100%" width="100%" visible="false">
            <div>
                <img src="Images/error.gif" alt="error" />
                Error occured with the payment.
            </div>
            <div>
                Error message:<asp:literal id="litErrorMessage" runat="server" />
            </div>
        </asp:panel>
    </div>
</asp:content>
