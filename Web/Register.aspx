<%@ page language="C#" autoeventwireup="true" codefile="Register.aspx.cs" inherits="Register"
    masterpagefile="~/MasterPages/CambodianLeftColumn.master" %>

<asp:content contentplaceholderid="cphMain" runat="server">
    <div class="col-main">
        <div class="my-account">
            <div class="page-title">
                <h1>
                    New Account Details</h1>
            </div>
            <div class="fieldset">
                <h2 class="legend">
                    Login Details</h2>
                <ul class="form-list">
                    <li class="wide">
                        <label for="email">
                            Email</label>
                        <div class="input-box">
                            <asp:textbox id="txtEmail" runat="server" textmode="singleLine" width="450px" cssclass="textField"></asp:textbox><br />
                            <asp:requiredfieldvalidator id="requiredEmail" runat="server" controltovalidate="txtEmail"
                                display="Dynamic" enableclientscript="False" errormessage="Email required." width="152px"></asp:requiredfieldvalidator>
                        </div>
                    </li>
                    <li class="wide">
                        <label for="confirmemail">
                            Confirm Email</label>
                        <div class="input-box">
                            <asp:textbox id="txtConfirmEmail" runat="server" textmode="singleLine" width="176px"
                                cssclass="textField"></asp:textbox><br />
                            <asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" controltovalidate="txtConfirmEmail"
                                display="Dynamic" enableclientscript="False" errormessage="Email required." width="152px"></asp:requiredfieldvalidator>
                        </div>
                    </li>
                    <li class="fields">
                        <div class="customer-name">
                            <div class="field name-firstname">
                                <label for="firstname" class="required">
                                    <em>*</em>Password</label>
                                <div class="input-box">
                                    <asp:textbox id="txtPassword" runat="server" textmode="Password" width="176px" cssclass="textField"></asp:textbox><br />
                                    <asp:requiredfieldvalidator id="requiredPassword" runat="server" controltovalidate="txtPassword"
                                        display="Dynamic" errormessage="Password required." width="152px" enableclientscript="False"></asp:requiredfieldvalidator>
                                    <asp:comparevalidator id="comparePasswords" runat="server" display="Dynamic" enableclientscript="False"
                                        errormessage="The passwords entered do not match" controltocompare="txtPassword"
                                        controltovalidate="txtConfirmPassword" width="240px"></asp:comparevalidator>
                                </div>
                            </div>
                            <div class="field name-lastname">
                                <label for="lastname" class="required">
                                    <em>*</em>Confirm Password</label>
                                <div class="input-box">
                                    <asp:textbox id="txtConfirmPassword" runat="server" textmode="Password" width="176px"
                                        cssclass="textField"></asp:textbox><br />
                                    <asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" controltovalidate="txtConfirmPassword"
                                        display="Dynamic" errormessage="Password required." width="152px" enableclientscript="False"></asp:requiredfieldvalidator>
                                </div>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="fieldset">
                <h2 class="legend">
                    Personal Details</h2>
                <ul class="form-list">
                    <li class="fields">
                        <div class="customer-name">
                            <div class="field name-firstname">
                                <label for="firstname" class="required">
                                    <em>*</em>First Name</label>
                                <div class="input-box">
                                    <asp:textbox id="txtFirstname" runat="server" width="176px" cssclass="textField"></asp:textbox><br />
                                    <asp:requiredfieldvalidator id="requiredFirstname" runat="server" controltovalidate="txtFirstname"
                                        display="Dynamic" enableclientscript="False" errormessage="Firstname required."
                                        width="152px"></asp:requiredfieldvalidator>
                                </div>
                            </div>
                            <div class="field name-lastname">
                                <label for="lastname" class="required">
                                    <em>*</em>Last Name</label>
                                <div class="input-box">
                                    <asp:textbox id="txtLastname" runat="server" width="176px" cssclass="textField"></asp:textbox><br />
                                    <asp:requiredfieldvalidator id="requiredLastname" runat="server" controltovalidate="txtLastname"
                                        display="Dynamic" enableclientscript="False" errormessage="Lastname required."
                                        width="152px"></asp:requiredfieldvalidator>
                                </div>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="fieldset">
                <h2 class="legend">
                    Address Details</h2>
                <ul class="form-list">
                    <li class="wide">
                        <label for="street_1" class="required">
                            <em>*</em>House number/name</label>
                        <div class="input-box">
                            <asp:textbox id="txtAddress" runat="server" width="176px" cssclass="textField"></asp:textbox><br />
                            <asp:requiredfieldvalidator id="requiredAddress" runat="server" controltovalidate="txtAddress"
                                display="Dynamic" enableclientscript="False" errormessage="Address required."
                                width="152px"></asp:requiredfieldvalidator>
                        </div>
                    </li>
                    <li class="wide">
                        <label for="street_1" class="required">
                            <em>*</em>Address line 1</label>
                        <div class="input-box">
                            <asp:textbox id="txtAddress2" runat="server" width="176px" cssclass="textField"></asp:textbox>
                        </div>
                    </li>
                    <li class="wide">
                        <label for="street_1" class="required">
                            <em>*</em>Address line 2</label>
                        <div class="input-box">
                            <asp:textbox id="txtAddress3" runat="server" width="176px" cssclass="textField"></asp:textbox>
                        </div>
                    </li>
                    <li class="fields">
                        <div class="field">
                            <label for="city" class="required">
                                <em>*</em>Town/City</label>
                            <div class="input-box">
                                <asp:textbox id="txtCity" runat="server" width="176px" cssclass="textField"></asp:textbox><br />
                                <asp:requiredfieldvalidator id="requiredCity" runat="server" controltovalidate="txtCity"
                                    display="Dynamic" enableclientscript="False" errormessage="City required." width="152px"></asp:requiredfieldvalidator>
                            </div>
                        </div>
                        <div class="field">
                            <label for="region_id" class="required">
                                <em>*</em>County</label>
                            <div class="input-box">
                                <asp:textbox id="txtState" runat="server" width="176px" cssclass="textField"></asp:textbox><br />
                                <asp:requiredfieldvalidator id="requiredState" runat="server" controltovalidate="txtState"
                                    display="Dynamic" enableclientscript="False" errormessage="State required." width="152px"></asp:requiredfieldvalidator>
                            </div>
                        </div>
                    </li>
                    <li class="fields">
                        <div class="field">
                            <label for="zip" class="required">
                                <em>*</em>PostCode</label>
                            <div class="input-box">
                                <asp:textbox id="txtPostalCode" runat="server" width="176px" cssclass="textField"></asp:textbox><br />
                                <asp:requiredfieldvalidator id="requiredPostalCode" runat="server" controltovalidate="txtPostalCode"
                                    display="Dynamic" enableclientscript="False" errormessage="Postal Code required."
                                    width="152px"></asp:requiredfieldvalidator>
                            </div>
                        </div>
                        <div class="field">
                            <label for="country" class="required">
                                <em>*</em>Country</label>
                            <div class="input-box">
                                <select name="country_id" id="country" class="validate-select" title="Country">
                                    <option value=""></option>
                                    <option value="AF">Afghanistan</option>
                                </select>
                            </div>
                        </div>
                    </li>
                    <li class="fields">
                        <div class="field">
                            <label for="telephone" class="required">
                                <em>*</em>Telephone</label>
                            <div class="input-box">
                                <asp:textbox id="txtPhone" runat="server" width="176px" cssclass="textField"></asp:textbox>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="fieldset">
                <ul class="form-list">
                    <li class="control">
                        <input type="checkbox" id="Checkbox1" name="default_billing" value="1" title="Use as My Default Billing Address"
                            class="checkbox" /><label for="primary_billing">Use as my default billing address</label>
                    </li>
                    <li class="control">
                        <input type="checkbox" id="Checkbox2" name="default_shipping" value="1" title="Use as My Default Shipping Address"
                            class="checkbox" /><label for="primary_shipping">Use as my default shipping address</label>
                    </li>
                    <li class="control">
                        <asp:checkbox id="chkNewsletter" runat="server" width="20px" /><label for="primary_shipping">Subscribe
                            to newsletter</label>
                    </li>
                </ul>
            </div>
            <div class="buttons-set">
                <p class="required">
                    * Required Fields</p>
                <p class="back-link">
                    <a href="http://sheets.worryfreelabs.com/customer/address/"><small>&laquo; </small>Back</a></p>
                <asp:imagebutton id="btnRegister" runat="server" imageurl="~/Images/save-address.png"
                    onclick="btnRegister_Click" />
            </div>
        </div>
    </div>
    <div class="col-left sidebar">
        <div class="block block-account">
            <div class="block-title">
                <strong><span>My Account</span></strong>
            </div>
            <div class="block-content">
                <ul>
                    <li><a href="account.html">Account Dashboard</a></li>
                    <li><a href="account_edit.html">Account Information</a></li>
                    <li class="current"><strong>Address Book</strong></li>
                    <li><a href="account_myorders.html">My Orders</a></li>
                    <li><a href="account_reviews.html">My Product Reviews</a></li>
                    <li><a href="account_wishlist.html">My Wishlist</a></li>
                </ul>
            </div>
        </div>
    </div>
</asp:content>
