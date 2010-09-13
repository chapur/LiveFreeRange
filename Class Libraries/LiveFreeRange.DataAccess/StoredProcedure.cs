using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.DataAccess
{
    public class StoredProcedure
    {
        public enum Name
        { 
            ProductById_Select,
            Products_Select,
            Products_SelectSearch,
            ProductCategory_Select,
            ProductPromotion_Select,
            ShoppingCart_Select,
            EndUserLogin_Select,
            AdminLogin_Select,
            Orders_Select,
            OrderDetails_Select,
            OrdersAll_Select,
            OrderStatus_Select,
            OrdersById_Select,
            Newsletter_Select,
            ContactInformation_Select,
            ProductColour_Select,
            ProductWeight_Select,
            ProductSize_Select,
            SubCategory_Select,
            SubCategoryByProductCategoryId_Select,
            ProductCategoryById_Select,
            ProductsByCategoryId_Select,
            ProductsBySubCategoryId_Select,
            ShowcaseByPageId_Select,
            ProductName_Select,
            ProductsByName_Select,
            ProductById_SelectNew,
            ProductStockLevelById_Select,
            
            Product_Insert,
            ShoppingCart_Insert,
            EndUser_Insert,
            Order_Insert,
            OrderDetails_Insert,
            Showcase_Insert,

            ShoppingCart_Update,
            Product_Update,
            NewsletterUnsubscribe_Update,
            Orders_Update,
            StockLevel_Update,

            ShoppingCart_Delete,
            ShoppingCartByGuid_Delete
        }
    }
}
