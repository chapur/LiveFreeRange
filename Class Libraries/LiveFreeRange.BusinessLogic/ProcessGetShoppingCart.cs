using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetShoppingCart : IBusinessLogic
    {
        public DataSet ResultSet{ get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public ProcessGetShoppingCart()
        { }

        public void Invoke()
        {
            ShoppingCartSelectData shoppingCartData = new ShoppingCartSelectData();
            shoppingCartData.ShoppingCart = ShoppingCart;
            ResultSet = shoppingCartData.Get();

            ShoppingCart.CartGuid = ResultSet.Tables[0].Rows[0]["CartGuid"].ToString();
            ShoppingCart.DateCreated = Convert.ToDateTime(ResultSet.Tables[0].Rows[0]["DateCreated"]);
            ShoppingCart.ProductId = Convert.ToInt32(ResultSet.Tables[0].Rows[0]["ProductId"]);
            ShoppingCart.ProductSize = ResultSet.Tables[0].Rows[0]["ProductSizeName"].ToString();
            ShoppingCart.ProductSizeId = Convert.ToInt32(ResultSet.Tables[0].Rows[0]["ProductSizeId"]);
            ShoppingCart.Quantity = Convert.ToInt32(ResultSet.Tables[0].Rows[0]["Quantity"]);
        }
    }
}
