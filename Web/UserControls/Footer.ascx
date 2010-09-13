<%@ control language="C#" autoeventwireup="true" codefile="Footer.ascx.cs" inherits="UserControls_Footer" %>
<div class="footer">
    <div class="footerLinks">
        <ul>
            <li><a href="about_us.html">About Us</a></li>
            <li class="last"><a href="customer-service.html">Customer Service</a></li>
        </ul>
    </div>
    <div class="right">
        <form action="#" method="post" id="newsletter-validate-detail">
        <label for="newsletter">
            Join our mailing list:</label>
        <input type="text" name="email" id="newsletter" title="Sign up for our newsletter"
            class="input-text required-entry validate-email" />
        <button type="submit" class="button">
            <span><span>Join</span></span></button>
        </form>
    </div>
    <div class="social-links">
        <a href="#">
            <img src="images/i_facebook.png" alt="Facebook" /></a> <a href="#">
                <img src="images/i_twitter.png" alt="Twitter" /></a>
    </div>
    <div class="legality">
        <div class="left">
            <strong>Sheets</strong> Your Address, Someplace, USA 1235
        </div>
        <div class="right">
            &copy; 2010 Sheets Demo Store. All Rights Reserved.</div>
    </div>
</div>
