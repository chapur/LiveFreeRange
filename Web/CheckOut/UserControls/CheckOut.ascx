<%@ control language="C#" autoeventwireup="true" codefile="CheckOut.ascx.cs" inherits="UserControls_CheckOut" %>
<div>
    <asp:gridview id="gvShoppingCart" runat="server" autogeneratecolumns="false" showheader="true"
        width="100%" datakeynames="Quantity, ShoppingCartId" onrowdatabound="gvShoppingCart_RowDataBound">
        <columns>
            <asp:templatefield headertext="Product">
                <itemtemplate>
                    <%#Eval("ProductName") %>
                </itemtemplate>
            </asp:templatefield>
            <asp:templatefield headertext="Quantity">
                <itemtemplate>
                    <%#Eval("Quantity") %>
                </itemtemplate>
            </asp:templatefield>
            <asp:templatefield headertext="Unit Cost">
                <itemtemplate>
                    <%#Eval("UnitPrice", "{0:c}") %>
                </itemtemplate>
            </asp:templatefield>
            <asp:templatefield headertext="Subtotal">
                <itemtemplate>
                    <%#Eval("TotalPrice","{0:c}") %>
                </itemtemplate>
            </asp:templatefield>
        </columns>
    </asp:gridview>
</div>
<div>
    <b>Subtotal:</b>
</div>
<div>
    <asp:literal id="litSubTotal" runat="server" />
</div>
<hr />
<div>
    <b>Tax</b>
</div>
<div>
    <asp:literal id="litTax" runat="server" />
</div>
<hr />

<asp:radiobuttonlist id="rblPaymentType" runat="server" onselectedindexchanged="rblPaymentType_OnSelectedIndexChanged"
    autopostback="true">
    <asp:listitem text="Credit Card" value="CC" />
    <asp:listitem text="PayPal" value="PP" />
</asp:radiobuttonlist>

<asp:placeholder id="phCreditCard" runat="server" visible="false">
    <table>
        <tr>
            <td>
                <b>Shipping Information</b>
            </td>
        </tr>
        <tr>
            <td>
                First Name:
            </td>
            <td>
                <asp:textbox id="txtFirstName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Last Name:
            </td>
            <td>
                <asp:textbox id="txtLastName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Address:
            </td>
            <td>
                <asp:textbox id="txtAddress" runat="server" />
                <asp:requiredfieldvalidator id="requiredAddress" runat="server" display="Dynamic"
                    enableclientscript="false" errormessage="Address Required" controltovalidate="txtAddress" />
            </td>
        </tr>
        <tr>
            <td>
                Address 2:
            </td>
            <td>
                <asp:textbox id="txtAddress2" runat="server" />
                <asp:requiredfieldvalidator id="requiredAddress2" runat="server" display="Dynamic"
                    enableclientscript="false" errormessage="Address Required" controltovalidate="txtAddress2" />
            </td>
        </tr>
        <tr>
            <td>
                City:
            </td>
            <td>
                <asp:textbox id="txtCity" runat="server" />
                <asp:requiredfieldvalidator id="requiredCity" runat="server" display="Dynamic" enableclientscript="false"
                    errormessage="City Required" controltovalidate="txtCity" />
            </td>
        </tr>
        <tr>
            <td>
                Post code:
            </td>
            <td>
                <asp:textbox id="txtPostalCode" runat="server" />
                <asp:requiredfieldvalidator id="requiredPostalCode" runat="server" display="Dynamic"
                    enableclientscript="false" errormessage="Post code Required" controltovalidate="txtPostalCode" />
            </td>
        </tr>
        <tr>
            <td>
                Shipping options:
            </td>
            <td>
                <asp:dropdownlist id="ddlShippingOption" runat="server">
                    <asp:listitem value="5.99">Ground £5.99</asp:listitem>
                    <asp:listitem value="8.99">2nd Day £8.99</asp:listitem>
                    <asp:listitem value="10.99">Next Day Air £10.99</asp:listitem>
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td>
                Credit Card:
            </td>
            <td>
                <asp:dropdownlist id="ddlCreditCardType" runat="server">
                    <asp:listitem text="Visa" value="Visa" />
                    <asp:listitem text="Master Card" value="MasterCard" />
                    <asp:listitem text="American Express" value="Amex" />
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td>
                Credit card number:
            </td>
            <td>
                <asp:textbox id="txtCreditCardNumber" runat="server" />
                <asp:requiredfieldvalidator id="requiredCreditCardNumber" runat="server" display="Dynamic"
                    enableclientscript="false" controltovalidate="txtCreditCardNumber" errormessage="Credit card number required" />
            </td>
        </tr>
        <tr>
            <td>
                Security Code:
            </td>
            <td>
                <asp:textbox id="txtSecurityCode" runat="server" />
                <asp:requiredfieldvalidator id="requiredSecurityCode" runat="server" display="Dynamic"
                    enableclientscript="false" errormessage="Security code required" controltovalidate="txtSecurityCode" />
            </td>
        </tr>
        <tr>
            <td>
                Expiration date:
            </td>
            <td>
                <asp:dropdownlist id="ddlExpMonth" runat="server">
                    <asp:listitem text="01" value="01" />
                    <asp:listitem text="02" value="02" />
                    <asp:listitem text="03" value="03" />
                    <asp:listitem text="04" value="04" />
                    <asp:listitem text="05" value="05" />
                    <asp:listitem text="06" value="06" />
                    <asp:listitem text="07" value="07" />
                    <asp:listitem text="08" value="08" />
                    <asp:listitem text="09" value="09" />
                    <asp:listitem text="10" value="10" />
                    <asp:listitem text="11" value="11" />
                    <asp:listitem text="12" value="12" />
                </asp:dropdownlist>
                <asp:dropdownlist id="ddlExpYear" runat="server">
                    <asp:listitem text="2006" value="2006" />
                    <asp:listitem text="2007" value="2007" />
                    <asp:listitem text="2008" value="2008" />
                    <asp:listitem text="2009" value="2009" />
                    <asp:listitem text="2010" value="2010" />
                    <asp:listitem text="2011" value="2011" />
                    <asp:listitem text="2012" value="2012" />
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td>
                <hr />
                <b>Billing Address</b>
            </td>
        </tr>
        <tr>
            <td>
                Address:
            </td>
            <td>
                <asp:textbox id="txtBillingAddress" runat="server" />
                <asp:requiredfieldvalidator id="requiredBillingAddress" runat="server" display="Dynamic"
                    enableclientscript="false" errormessage="Billing address required" controltovalidate="txtBillingAddress" />
            </td>
        </tr>
        <tr>
            <td>
                Address 2:
            </td>
            <td>
                <asp:textbox id="txtBillingAddress2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                City:
            </td>
            <td>
                <asp:textbox id="txtBillingCity" runat="server" />
                <asp:requiredfieldvalidator id="requiredBillingCity" runat="server" display="Dynamic"
                    enableclientscript="false" errormessage="Billing city required" controltovalidate="txtBillingCity" />
            </td>
        </tr>
        <tr>
            <td>
                Postal code:
            </td>
            <td>
                <asp:textbox id="txtBillingPostalCode" runat="server" />
                <asp:requiredfieldvalidator id="requiredBillingPostalCode" runat="server" display="Dynamic"
                    enableclientscript="false" errormessage="Billing Post code required" controltovalidate="txtBillingPostalCode" />
            </td>
        </tr>
        <div>
            <asp:button id="btnSubmit" runat="server" text="Continue" onclick="btnSubmit_Click" />
        </div>
    </table>
</asp:placeholder>

<asp:placeholder id="phPayPal" runat="server" visible="false">
    <div>
        <input type='image' name='submit' src='https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif'
            border='0' align='top' alt='PayPal' />
        <asp:placeholder id="phPaypalPayment" runat="server" visible="true">
            <asp:literal id="litPaypalIntroduction" runat="server" />
            <br />
            <br />
            <asp:literal id="litPaypalFormElements" runat="server" />
            <asp:literal id="litHashtableContents" runat="server" />
            <asp:placeholder id="phPaypalButtonEncrypted" runat="server">
                <input type="hidden" name="cmd" value="_s-xclick" />
                <asp:imagebutton id="ibGetPaypalToken" runat="server" onclick="ibGetPaypalToken_Click" />
            </asp:placeholder>
        </asp:placeholder>
        <asp:placeholder id="phPaypalPaymentCompletion" runat="server" visible="true">
            <asp:literal id="litPaypalLoginMessage" runat="server" />
            <br />
            <br />
            <asp:imagebutton id="ibCompletePaypalOrder" runat="server" imageurl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif"
                borderwidth="0" alternatetext="PayPal" onclick="ibCompletePaypalOrder_Click" />
        </asp:placeholder>
    </div>
</asp:placeholder>
