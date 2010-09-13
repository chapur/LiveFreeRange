using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class Orders
    {
        private int _orderId;
        private int _endUserId;
        private EndUser _endUser;
        private string _transactionId;
        private DateTime _orderDate;
        private Address _shippingAddress;
        private int _orderStatusId;
        private decimal _shippingTotal;
        private OrderDetails _orderDetails;
        private decimal _subTotal;
        private decimal _orderTotal;
        private decimal _tax;
        private CreditCard _creditCard;
        private DateTime _shipDate;
        private string _trackingNumber;
        private string _payerId;

        public string PayerId
        {
            get { return _payerId; }
            set { _payerId = value; }
        }

        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        
        public int EndUserId
        {
            get { return _endUserId; }
            set { _endUserId = value; }
        }
        

        public EndUser Enduser
        {
            get { return _endUser; }
            set { _endUser = value; }
        }
       
        public string TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }
        
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }
        
        public Address ShippingAddress
        {
            get { return _shippingAddress; }
            set { _shippingAddress = value; }
        }
        
        public int OrderStatusId
        {
            get { return _orderStatusId; }
            set { _orderStatusId = value; }
        }
        
        public decimal ShippingTotal
        {
            get { return _shippingTotal; }
            set { _shippingTotal = value; }
        }

        public OrderDetails OrderDetails
        {
            get { return _orderDetails; }
            set { _orderDetails = value; }
        }

        public decimal SubTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }

        public decimal OrderTotal
        {
            get { return _orderTotal; }
            set { _orderTotal = value; }
        }

        public decimal Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }

        public CreditCard CreditCard
        {
            get { return _creditCard; }
            set { _creditCard = value; }
        }

        public DateTime ShipDate
        {
            get { return _shipDate; }
            set { _shipDate = value; }
        }

        public string TrackingNumber
        {
            get { return _trackingNumber; }
            set { _trackingNumber = value; }
        }

        public Orders()
        {
            _creditCard = new CreditCard();
            _orderDetails = new OrderDetails();
            _endUser = new EndUser();
            _shippingAddress = new Address();
        }
    }
}
