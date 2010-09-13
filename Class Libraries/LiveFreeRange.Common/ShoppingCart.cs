    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class ShoppingCart
    {
        public ShoppingCart()
        { }

        public int ShoppingCartId {get; set;}

        public string CartGuid { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public string ProductSize { get; set; }

        public int ProductSizeId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
