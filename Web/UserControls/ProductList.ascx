<%@ control language="C#" autoeventwireup="true" codefile="ProductList.ascx.cs" inherits="UserControls_ProductList" %>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
<div class="col-main">
    <div class="category-products">
        <div class="toolbar">
            <div>
                <p class="view-mode">
                    <label>
                        View as:</label>
                    <select>
                        <option value="http://sheets.worryfreelabs.com/men/shorts.html?mode=grid" selected="selected">
                            Grid</option>
                        <option value="http://sheets.worryfreelabs.com/men/shorts.html?mode=list">List</option>
                    </select>
                </p>
                <div class="sort-by">
                    <label>
                        Sort by</label>
                    <select onchange="setLocation(this.value)">
                        <option value="postion" selected="selected">Position</option>
                        <option value="name">Name</option>
                        <option value="price">Price</option>
                    </select>
                    <a href="#" title="Set Descending Direction">&uarr;</a>
                </div>
                <div class="limiter">
                    <label>
                        Show</label>
                    <select onchange="setLocation(this.value)">
                        <option value="9" selected="selected">9 per page</option>
                        <option value="15">15 per page</option>
                        <option value="30">30 per page</option>
                    </select>
                </div>
            </div>
        </div>
        <asp:listview id="lvProductList" runat="server" onitemdatabound="lvProductList_OnItemDataBound">
            <layouttemplate>
                <ul class="products-grid">
                    <asp:placeholder id="itemPlaceholder" runat="server" />
                </ul>
            </layouttemplate>
            <itemtemplate>
                <li class="item">
                    <asp:hyperlink id="hlProduct" runat="server">
                        <asp:image id="imgProduct" runat="server" /><br />
                        <h2 class="product-name">
                            <asp:literal id="litProductName" runat="server" /></h2>
                    </asp:hyperlink>
                    <div class="price-box">
                        <span class="regular-price" id="product-price-5"><span class="price">
                            <asp:literal id="litProductPrice" runat="server" /></span> </span>
                    </div>
                </li>
            </itemtemplate>
        </asp:listview>
    </div>
</div>
<div class="col-left sidebar">
    <div class="block block-layered-nav">
        <div class="block-title">
            <strong><span>Shop By</span></strong>
        </div>
        <div class="block-content">
            <p class="block-subtitle">
                Shopping Options</p>
            <dl id="narrow-by-list">
                <dt>Price</dt>
                <dd>
                    <ol>
                        <li><a href="product.html"><span class="price">$40.00</span> - <span class="price">$50.00</span></a>
                            (1) </li>
                        <li><a href="product.html"><span class="price">$50.00</span> - <span class="price">$60.00</span></a>
                            (1) </li>
                    </ol>
                </dd>
            </dl>
        </div>
    </div>
</div>
