<%@ control language="C#" autoeventwireup="true" codefile="ProductDetailsNew.ascx.cs"
    inherits="UserControls_ProductDetailsNew" %>
<div>
    <asp:literal id="litProductCategory" runat="server" />
</div>
<div>
</div>
<div class="col-main">
    <div id="messages_product_view">
    </div>
    <div class="product-view">
        <div class="product-essential">
            <div class="no-display">
                <input type="hidden" name="product" value="5" />
                <input type="hidden" name="related_product" id="related-products-field" value="" />
            </div>
            <div class="product-img-box">
                <p class="product-image">
                <asp:hyperlink id="hlProductImage" runat="server" cssclass="fancybox">
                        <asp:image id="imgProduct" runat="server" width="278" height="278" /></asp:hyperlink>
                </p>
                <div class="more-views">
                    <ul>
                        <li class=""><a href="images/look-two.png" rel="more-views" class="fancybox" title="">
                            <img src="images/look-two.png" alt="" /></a> </li>
                        <li class=""><a href="images/look-three.png" rel="more-views" class="fancybox" title="">
                            <img src="images/look-three.png" alt="" /></a> </li>
                        <li class=""><a href="images/look-four.png" rel="more-views" class="fancybox" title="">
                            <img src="images/look-four.png" alt="" /></a> </li>
                        <li class=""><a href="images/look-five.png" rel="more-views" class="fancybox" title="">
                            <img src="images/look-five.png" alt="" /></a> </li>
                    </ul>
                </div>
            </div>
            <div class="product-shop">
                <div class="product-name">
                    <h1>
                        <asp:literal id="litProductName" runat="server" /></h1>
                </div>
                <p class="ratings no-rating">
                    <a href="#customer-reviews">Be the first to review this product</a></p>
                <div class="description">
                    <h4>
                        Description</h4>
                    <asp:literal id="litProductDescription" runat="server" />
                    <asp:literal id="litError" runat="server" />
                    <asp:dropdownlist id="ddlSizes" runat="server">
                        <asp:listitem text="Select a size..." />
                    </asp:dropdownlist>
                    <asp:placeholder id="phOutOfStock" runat="server">
                        <asp:literal id="litOutOfStock" runat="server" />
                    </asp:placeholder>
                    <asp:hyperlink id="hlContinueShopping" runat="server" text="Continue Shopping" />
                </div>
            </div>
            <div class="custom-box">
                <div class="custom-box-upper">
                    <div class="price-box">
                        <span class="regular-price" id="product-price-5"><span class="price">
                            <asp:literal id="litPrice" runat="server" /></span> </span>
                    </div>
                    <p class="availability in-stock">
                        Availability: <span>In stock</span></p>
                    <div class="add-to-cart">
                        <label for="qty">
                            Qty:</label>
                        <asp:textbox id="txtQuantity" runat="server" columns="1" /><br />
                        <br />
                        <asp:requiredfieldvalidator id="rfvQuantity" runat="server" controltovalidate="txtQuantity"
                            errormessage="Please select a quantity" />
                        <asp:imagebutton id="btnAddToBasket" runat="server" imageurl="~/Images/AddToBasket.png"
                            onclick="btnAddToBasket_Click" />
                    </div>
                </div>
                <div class="custom-box-lower">
                    <ul class="add-to-links">
                        <li><a href="wishlist.html" class="link-wishlist">Add to Wishlist</a></li>
                        <li><a href="#" class="link-compare">Add to Compare</a></li>
                    </ul>
                    <p class="email-friend">
                        <a href="#">Email to a Friend</a></p>
                </div>
            </div>
            <div class="clearer">
            </div>
            </form>
        </div>
        <div class="product-collateral">
            <div class="box-collateral" id="product-reviews">
                <div class="box-reviews" id="customer-reviews">
                    <h2>
                        Customer Reviews</h2>
                    <p>
                        No reviews yet</p>
                </div>
                <form action="#" method="post" id="review-form">
                <div class="form-add">
                    <h2>
                        Write Your Own Review</h2>
                    <ul class="form-list">
                        <li>
                            <label for="nickname_field" class="required">
                                <em>*</em>Nickname</label>
                            <div class="input-box">
                                <input type="text" name="nickname" id="nickname_field" class="input-text required-entry"
                                    value="" />
                            </div>
                        </li>
                        <li>
                            <label for="summary_field" class="required">
                                <em>*</em>Summary of Your Review</label>
                            <div class="input-box">
                                <input type="text" name="title" id="summary_field" class="input-text required-entry"
                                    value="" />
                            </div>
                        </li>
                        <li>
                            <label for="review_field" class="required">
                                <em>*</em>Review</label>
                            <div class="input-box">
                                <textarea name="detail" id="review_field" cols="5" rows="3" class="required-entry"></textarea>
                            </div>
                        </li>
                    </ul>
                    <h4>
                        How do you rate this product? <em class="required">*</em></h4>
                    <span id="input-message-box"></span>
                    <table class="data-table" id="product-review-table">
                        <col />
                        <col width="1" />
                        <col width="1" />
                        <col width="1" />
                        <col width="1" />
                        <col width="1" />
                        <thead>
                            <tr>
                                <th>
                                    &nbsp;
                                </th>
                                <th>
                                    <span class="nobr">1 star</span>
                                </th>
                                <th>
                                    <span class="nobr">2 stars</span>
                                </th>
                                <th>
                                    <span class="nobr">3 stars</span>
                                </th>
                                <th>
                                    <span class="nobr">4 stars</span>
                                </th>
                                <th>
                                    <span class="nobr">5 stars</span>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th>
                                    Value
                                </th>
                                <td class="value">
                                    <input type="radio" name="ratings[2]" id="Value_1" value="6" class="radio" />
                                </td>
                                <td class="value">
                                    <input type="radio" name="ratings[2]" id="Value_2" value="7" class="radio" />
                                </td>
                                <td class="value">
                                    <input type="radio" name="ratings[2]" id="Value_3" value="8" class="radio" />
                                </td>
                                <td class="value">
                                    <input type="radio" name="ratings[2]" id="Value_4" value="9" class="radio" />
                                </td>
                                <td class="value">
                                    <input type="radio" name="ratings[2]" id="Value_5" value="10" class="radio" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Quality
                                </th>
                                <td class="value">
                                    <input type="radio" name="ratings[1]" id="Quality_1" value="1" class="radio" />
                                </td>
                                <td class="value">
                                    <input type="radio" name="ratings[1]" id="Quality_2" value="2" class="radio" />
                                </td>
                                <td class="value">
                                    <input type="radio" name="ratings[1]" id="Quality_3" value="3" class="radio" />
                                </td>
                                <td class="value">
                                    <input type="radio" name="ratings[1]" id="Quality_4" value="4" class="radio" />
                                </td>
                                <td class="value">
                                    <input type="radio" name="ratings[1]" id="Quality_5" value="5" class="radio" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <input type="hidden" name="validate_rating" class="validate-rating" value="" />
                </div>
                <div class="buttons-set">
                    <button type="submit" title="Submit Review" class="button">
                        <span><span>Submit Review</span></span></button>
                </div>
                </form>
            </div>
            <div class="box-collateral box-tags">
                <h2>
                    Product Tags</h2>
                <form id="addTagForm" action="#" method="get">
                <div class="form-add">
                    <label for="productTagName">
                        Add Your Tags:</label>
                    <div class="input-box">
                        <input type="text" class="input-text required-entry" name="productTagName" id="productTagName" />
                    </div>
                    <button type="button" title="Add Tags" class="button" onclick="submitTagForm()">
                        <span><span>Add Tags</span> </span>
                    </button>
                </div>
                <p class="note">
                    Use spaces to separate tags. Use single quotes (') for phrases.</p>
            </div>
        </div>
    </div>
</div>
