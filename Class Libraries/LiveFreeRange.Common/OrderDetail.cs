using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class OrderDetails
    {
        public OrderDetails()
        { }

        private int _orderDetailId;

        public int OrderDetailId
        {
            get { return _orderDetailId; }
            set { _orderDetailId = value; }
        }

        private int _orderId;

        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        private Product[] _products;

        public Product[] Products
        {
            get { return _products; }
            set { _products = value; }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
    }
}
