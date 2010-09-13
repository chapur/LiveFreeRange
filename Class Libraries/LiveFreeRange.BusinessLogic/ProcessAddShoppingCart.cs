using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Insert;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessAddShoppingCart : IBusinessLogic
    {
        public ProcessAddShoppingCart()
        { }

        public void Invoke()
        {
            ShoppingCartInsertData shoppingCartData = new ShoppingCartInsertData();
            shoppingCartData.ShoppingCart = this.ShoppingCart;
            shoppingCartData.Add();
        }

        private ShoppingCart _shoppingCart;

        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }
    }
}
