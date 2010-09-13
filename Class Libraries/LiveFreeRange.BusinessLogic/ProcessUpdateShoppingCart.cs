using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Update;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessUpdateShoppingCart : IBusinessLogic
    {
        private ShoppingCart _shoppingCart;

        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }

        public void Invoke()
        {
            ShoppingCartUpdateData shoppingCartData = new ShoppingCartUpdateData();
            shoppingCartData.ShoppingCart = this.ShoppingCart;
            shoppingCartData.Update();
        }
    }
}
