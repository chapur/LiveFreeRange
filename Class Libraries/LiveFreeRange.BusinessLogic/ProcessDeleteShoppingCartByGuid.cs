using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Delete;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessDeleteShoppingCartByGuid
    {
        private ShoppingCart _shoppingCart;

        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }

        public ProcessDeleteShoppingCartByGuid()
        { }

        public void Invoke()
        {
            ShoppingCartByGuidDeleteData shoppingCartData = new ShoppingCartByGuidDeleteData();
            shoppingCartData.ShoppingCart = this.ShoppingCart;
            shoppingCartData.Delete();
        }
    }
}
