<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test"%>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
<title>Home page</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" content="Default Description" />
<meta name="keywords" content="Sheets, Varien, E-commerce" />
<meta name="robots" content="INDEX,FOLLOW" />
<link rel="icon" href="images/favicon.ico" type="image/x-icon" />
<link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
<!--[if lt IE 7]>
<script type="text/javascript">
//<![CDATA[
    var BLANK_URL = 'js/blank.html';
    var BLANK_IMG = 'js/spacer.gif';
//]]>
</script>
<![endif]-->
<link rel="stylesheet" type="text/css" href="css/widgets.css" media="all" />
<link rel="stylesheet" type="text/css" href="css/styles.css" media="all" />
<link rel="stylesheet" type="text/css" href="css/custom.css" media="all" />
<link rel="stylesheet" type="text/css" href="fancybox/jquery.fancybox-1.3.1.css" media="all" />
<link rel="stylesheet" type="text/css" href="css/print.css" media="print" />

<script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="http://sheets.worryfreelabs.com/skin/frontend/base/default/js/jquery.curvycorners.min.js"></script>
<script type="text/javascript" src="http://sheets.worryfreelabs.com/skin/frontend/base/default/js/tastyimage.js"></script>
<script type="text/javascript" src="fancybox/jquery.fancybox-1.3.1.js"></script>
<script type="text/javascript" src="js/sheets.js"></script>
<!--[if lt IE 9]>
<link rel="stylesheet" type="text/css" href="css/styles-ie.css" media="all" />
<![endif]-->
<!--[if lt IE 7]>
<script type="text/javascript" src="js/ds-sleight.js"></script>
<![endif]-->

<link rel="stylesheet" type="text/css" href="css/overrides.css" media="all" />
<script type="text/javascript" src="js/jquery-ui-1.8.4.custom.min.js"></script>
<script type="text/javascript" src="js/home_slider.js"></script>
<script type="text/javascript" >
	jQuery.noConflict();
	jQuery(document).ready(function(){
		jQuery('.sheets-gallery ul li').accordionSlider();
	});
</script>

</head>

<body class="cms-index-index cms-home">
<div class="wrapper">
    <noscript>
    <div class="noscript">
        <div class="noscript-inner">
            <p><strong>JavaScript seem to be disabled in your browser.</strong></p>
            <p>You must have JavaScript enabled in your browser to utilize the functionality of this website.</p>
        </div>
    </div>
	</noscript>
    <div class="page">
        <div class="header-container">
    		<div class="header">
        		<div class="quick-access">
            		<span class="welcome-msg">Welcome, Customer!</span>
            		<ul class="links">
			            <li class="first" ><a href="account.html" title="My Account" >My Account</a></li>
			            <li ><a href="wishlist.html" title="My Wishlist" class="top-link-wishlist">My Wishlist</a></li>
			            <li ><a href="cart.html" title="My Cart" class="top-link-cart">My Cart</a></li>
			            <li ><a href="checkout.html" title="Checkout" class="top-link-checkout">Checkout</a></li>
			            <li class=" last" ><a href="login.html" title="Log In" >Log In</a></li>
    				</ul>
                </div>
                <h1 class="logo"><a href="home.html" title="Sheets"><img src="images/logo.gif" alt="Sheets" /></a></h1>
                <div class="nav-container">        
    				<ul id="nav">
        				<li class="level0 nav-1 level-top first parent">
							<a href="product_listing.html" class="level-top">
								<span>Men</span>
							</a>
							<ul class="level0">
								<li class="level1 nav-1-1 first">
									<a href="product_listing.html">
										<span>Pants</span>
									</a>
								</li>
								<li class="level1 nav-1-2 last">
									<a href="product_listing.html">
										<span>Shorts</span>
									</a>
								</li>
							</ul>
						</li>
						<li class="level0 nav-2 level-top parent">
							<a href="product_listing.html" class="level-top">
								<span>Women</span>
							</a>
							<ul class="level0">
								<li class="level1 nav-2-1 first">
									<a href="product_listing.html">
										<span>Shirts</span>
									</a>
								</li>
								<li class="level1 nav-2-2 last">
									<a href="product_listing.html">
										<span>Pants</span>
									</a>
								</li>
							</ul>
						</li>
						<li class="level0 nav-3 level-top last">
							<a href="product_listing.html" class="level-top">
								<span>Kids</span>
							</a>
						</li>    
					</ul>

          			<form id="search_mini_form" action="#" method="get">
				    <div class="form-search">
				        <label for="search">Search:</label>
				        <input id="search" type="text" name="q" value="" class="input-text" />
				        <button type="submit" title="Search" class="button"><span><span>Search</span></span></button>
				    </div>
					</form>
        		</div>
    		</div>
		</div>
		<!-- end header container -->
        <div class="main-container col1-layout">
            <div class="main">
            	<div>
            		<div>
                    	<div class="col-main">
                        	<div class="std">
                        		<div class="sheets-gallery">
									<ul>
										<li id="li1" class="li1Closed" style="z-index: 5;">
											<div class="gallery-image"><img src="images/photo1.jpg" alt="" /></div>
											<div class="gallery-info">FASHION <span>for the</span> WHOLE <strong>FAMILY</strong> <a href="#"><span>Shop now</span></a></div>
											<div class="gallery-number">1</div>
										</li>
										<li id="li2" class="li2Closed" style="z-index: 4;">
											<div class="gallery-image"><img src="images/photo1.jpg" alt="" /></div>
											<div class="gallery-info">FASHION <span>for the</span> WHOLE <strong>FAMILY</strong> <a href="#"><span>Shop now</span></a></div>
											<div class="gallery-number">2</div>
										</li>
										<li id="li3" class="li3Closed" style="z-index: 3;">
											<div class="gallery-image"><img src="images/photo1.jpg" alt="" /></div>
											<div class="gallery-info">FASHION <span>for the</span> WHOLE <strong>FAMILY</strong> <a href="#"><span>Shop now</span></a></div>
											<div class="gallery-number">3</div>
										</li>
										<li id="li4" class="li4Closed" style="z-index: 2;">
											<div class="gallery-image"><img src="images/photo1.jpg" alt="" /></div>
											<div class="gallery-info">FASHION <span>for the</span> WHOLE <strong>FAMILY</strong> <a href="#"><span>Shop now</span></a></div>
											<div class="gallery-number">4</div>
										</li>
										<li id="li5" class="no-bg li5Closed" style="z-index: 1;">
											<div class="gallery-image"><img src="images/photo1.jpg" alt="" /></div>
											<div class="gallery-info">FASHION <span>for the</span> WHOLE <strong>FAMILY</strong> <a href="#"><span>Shop now</span></a></div>
											<div class="gallery-number">5</div>
										</li>
									</ul>
								</div>
								<div class="prom">
									<div class="left">
										<span style="font-size: 30px;">Crazy <strong>50% Off</strong> Sale!</span><br /> <span style="color: #91c0d9; font-size: large;">On now through Monday.</span>
									</div>
									<div class="right">
										<a href="#"><span>Shop now</span></a>
									</div>
								</div>
								<div class="daily-scoop">
									<h2>The Daily Scoop</h2>
									<p>Receive daily deals and coupons in your e-mail!</p>
									<form action=""> 
										<input class="input-text left" name="name" type="text" /> <button class="button"><span><span>Signup</span></span></button> 
									</form>
								</div>
							</div>                
						</div>
					</div>
				</div>
            </div>
        </div>
        <!-- start footer -->
        <div class="footer-container">
			<div class="footer">
        		<div class="footerLinks">
          			<ul>
						<li><a href="about_us.html">About Us</a></li>
						<li class="last"><a href="customer-service.html">Customer Service</a></li>
					</ul>        
				</div>
        		<div class="right">
              		<form action="#" method="post" id="newsletter-validate-detail">
            		<label for="newsletter">Join our mailing list:</label>
               		<input type="text" name="email" id="newsletter" title="Sign up for our newsletter" class="input-text required-entry validate-email" />
					<button type="submit" class="button"><span><span>Join</span></span></button>
    				</form>       
				</div>
        		<div class="social-links"> 
        			<a href="#"><img src="images/i_facebook.png" alt="Facebook" /></a> <a href="#"><img src="images/i_twitter.png" alt="Twitter" /></a>
        		</div>
        		<div class="legality">
          			<div class="left"><strong>Sheets</strong> Your Address, Someplace, USA 1235 </div>
          			<div class="right">&copy; 2010 Sheets Demo Store. All Rights Reserved.</div>
        		</div>
      		</div>
		</div>
    </div>
</div>
</body>
</html>