using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetAllOrders : IBusinessLogic
    {
        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public ProcessGetAllOrders()
        { 
        
        }

        public void Invoke()
        {
            OrdersAllSelectData ordersAll = new OrdersAllSelectData();
            ResultSet = ordersAll.Get();
        }
    }
}
