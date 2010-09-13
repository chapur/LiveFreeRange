using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Delete;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessDeleteShoppingCart : IBusinessLogic
    {
        private ShoppingCart _shoppingCart;

        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }

        public ProcessDeleteShoppingCart()
        { }

        public void Invoke()
        {
            ShoppingCartDeleteData shoppingCartData = new ShoppingCartDeleteData();
            shoppingCartData.ShoppingCart = this.ShoppingCart;
            shoppingCartData.Delete();
        }
    }
}
