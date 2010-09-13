using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetOrders : IBusinessLogic
    {
        private EndUser _endUser;

        public EndUser EndUser
        {
            get { return _endUser; }
            set { _endUser = value; }
        }
        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public ProcessGetOrders()
        { 
        
        }

        public void Invoke()
        {
            OrdersSelectData ordersSelect = new OrdersSelectData();
            ordersSelect.EndUser = this.EndUser;
            ResultSet = ordersSelect.Get();
        }
    }
}
