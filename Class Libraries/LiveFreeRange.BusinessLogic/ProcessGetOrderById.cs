using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetOrderById : IBusinessLogic
    {
        private Orders _orders;

        public Orders Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public ProcessGetOrderById()
        { 
        
        }

        public void Invoke()
        {
            OrdersSelectByIdData orderById = new OrdersSelectByIdData();
            orderById.Orders = this.Orders;
            this.ResultSet = orderById.Get();

            if (ResultSet.Tables[0].Rows.Count > 0)
            {
                if (ResultSet.Tables[0].Rows[0]["ShipDate"].ToString() != "")
                {
                    Orders.ShipDate = Convert.ToDateTime(ResultSet.Tables[0].Rows[0]["ShipDate"].ToString());
                }
                Orders.TrackingNumber = ResultSet.Tables[0].Rows[0]["TrackingNumber"].ToString();
                Orders.OrderStatusId = int.Parse(ResultSet.Tables[0].Rows[0]["OrderStatusId"].ToString());
            }
        }
    }
}
