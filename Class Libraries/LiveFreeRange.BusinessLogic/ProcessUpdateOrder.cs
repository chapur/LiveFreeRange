using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Update;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessUpdateOrder : IBusinessLogic
    {
        private Orders _orders;

        public Orders Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public ProcessUpdateOrder()
        { 
        
        }

        public void Invoke()
        {
            OrderUpdateData orderUpdate = new OrderUpdateData();
            orderUpdate.Orders = this.Orders;
            orderUpdate.Update();
        }
    }
}
