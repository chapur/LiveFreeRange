using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Transaction;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessAddOrder : IBusinessLogic
    {
        private Orders _orders;

        public Orders Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public ProcessAddOrder()
        { 
        
        }

        public void Invoke()
        {
            OrderInsertTransaction orderTransaction = new OrderInsertTransaction();
            orderTransaction.Begin(this.Orders);

            //remove basket and update stock level
        }
    }
}
