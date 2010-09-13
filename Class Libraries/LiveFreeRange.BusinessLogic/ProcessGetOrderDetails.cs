using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetOrderDetails : IBusinessLogic
    {
        private OrderDetails _orderDetails;

        public OrderDetails OrderDetails
        {
            get { return _orderDetails; }
            set { _orderDetails = value; }
        }
        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public ProcessGetOrderDetails()
        { 
        
        }

        public void Invoke()
        {
            OrderDetailsSelectData orderDetailsSelect = new OrderDetailsSelectData();
            orderDetailsSelect.OrderDetails = this.OrderDetails;
            ResultSet = orderDetailsSelect.Get();
        }



    }
}
