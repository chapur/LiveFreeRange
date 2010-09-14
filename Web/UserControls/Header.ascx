<%@ control language="C#" autoeventwireup="true" codefile="Header.ascx.cs" inherits="UserControls_Header" %>
<div class="header">
    <div class="quick-access">
        <span class="welcome-msg">Welcome, Customer!</span>
        <ul class="links">
            <li class="first"><a href="account.html" title="My Account">My Account</a></li>
            <li><a href="wishlist.html" title="My Wishlist" class="top-link-wishlist">My Wishlist</a></li>
            <li><a href="cart.html" title="My Cart" class="top-link-cart">My Cart</a></li>
            <li><a href="checkout.html" title="Checkout" class="top-link-checkout">Checkout</a></li>
            <li class=" last"><a href="login.aspx" title="Log In">Log In</a></li>
        </ul>
    </div>
    <h1 class="logo">
        <a href="default.aspx" title="Logo">
            <img src="images/Koi.png" alt="Sheets" /></a></h1>
    <div class="nav-container">
        <ul id="nav">
            <li class="level0 nav-1 level-top first parent"><asp:hyperlink id="hlClothing" runat="server" >
                <span>Clothing</span> </asp:hyperlink>
                <ul class="level0">
                    <li class="level1 nav-1-1 first"><a href="product_listing.html"><span>Pants</span> </a>
                    </li>
                    <li class="level1 nav-1-2 last"><a href="product_listing.html"><span>Shorts</span> </a>
                    </li>
                </ul>
            </li>
            <li class="level0 nav-2 level-top parent"><asp:hyperlink id="hlJewellery" runat="server">
                <span>Jewellery</span> </asp:hyperlink>
                <ul class="level0">
                    <li class="level1 nav-2-1 first"><a href="product_listing.html"><span>Shirts</span>
                    </a></li>
                    <li class="level1 nav-2-2 last"><a href="product_listing.html"><span>Pants</span> </a>
                    </li>
                </ul>
            </li>
            <li class="level0 nav-3 level-top last"><asp:hyperlink id="hlGifts" runat="server" >
                <span>Gifts</span></asp:hyperlink> </li>
        </ul>
        <form id="search_mini_form" action="#" method="get">
        <div class="form-search">
            <label for="search">
                Search:</label>
            <input id="search" type="text" name="q" value="" class="input-text" />
            <button type="submit" title="Search" class="button">
                <span><span>Search</span></span></button>
        </div>
        </form>
    </div>
</div>
