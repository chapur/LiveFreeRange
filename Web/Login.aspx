<%@ page language="C#" autoeventwireup="true" codefile="Login.aspx.cs" inherits="Login"
    masterpagefile="~/MasterPages/Cambodian.master" %>

<asp:content contentplaceholderid="cphMain" runat="server">
    <div class="col-main">
        <div class="account-login">
            <div class="page-title">
                <h1>
                    Login or Create an Account</h1>
            </div>
            <form action="#" method="post" id="login-form">
            <div class="col2-set">
                <div class="col-1 new-users">
                    <div class="content">
                        <h2>
                            New Customers</h2>
                        <p>
                            By creating an account with our store, you will be able to move through the checkout
                            process faster, store multiple shipping addresses, view and track your orders in
                            your account and more.</p>
                    </div>
                </div>
                <div class="col-2 registered-users">
                    <div class="content">
                        <h2>
                            Registered Customers</h2>
                        <p>
                            If you have an account with us, please log in.</p>
                        <ul class="form-list">
                            <li>
                                <label for="email" class="required">
                                    <em>*</em>Email Address</label>
                                <div class="input-box">
                                    <asp:textbox id="txtUsername" runat="server" text="jennifer.begg@gmail.com" columns="50" /><br />
                                    <asp:requiredfieldvalidator id="requiredUsername" runat="server" errormessage="Username required."
                                        controltovalidate="txtUsername" display="Dynamic" enableclientscript="false"></asp:requiredfieldvalidator>
                                </div>
                            </li>
                            <li>
                                <label for="pass" class="required">
                                    <em>*</em>Password</label>
                                <div class="input-box">
                                    <asp:textbox id="txtPassword" runat="server" text="password" textmode="Password"
                                        columns="50" /><br />
                                    <asp:requiredfieldvalidator id="requiredPassword" runat="server" errormessage="Password required."
                                        controltovalidate="txtPassword" display="Dynamic" enableclientscript="false"></asp:requiredfieldvalidator>
                                </div>
                                <div>
                                    <asp:literal id="litMessage" runat="server" />
                                </div>
                            </li>
                        </ul>
                        <p class="required">
                            <a href="forgot_password.html" class="f-left">Forgot Your Password?</a> <span>* Required
                                Fields</span></p>
                    </div>
                </div>
            </div>
            <div class="col2-set">
                <div class="col-1 new-users">
                    <div class="buttons-set">
                        <asp:hyperlink id="hlNewAccount" runat="server" navigateurl="Register.aspx">
                            <asp:image id="imgCreateAccount" runat="server" imageurl="~/Images/create-account.png" /></asp:hyperlink>
                    </div>
                </div>
                <div class="col-2 registered-users">
                    <div class="buttons-set">
                        <asp:imagebutton id="btnLogin" onclick="btnLogin_Click" runat="server" imageurl="Images/login.png" />
                    </div>
                </div>
            </div>
            </form>
        </div>
    </div>
</asp:content>
