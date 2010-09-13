using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Update
{
    public class OrderUpdateData : DataAccessBase
    {
        private Orders _orders;

        public Orders Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
        private OrderUpdateDataParameters _orderUpdateDataParameters;

        public OrderUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.Orders_Update.ToString();
        }

        public void Update()
        {
            _orderUpdateDataParameters = new OrderUpdateDataParameters(Orders);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Parameters = _orderUpdateDataParameters.Parameters;
            dbHelper.Run();
        }
    }

    public class OrderUpdateDataParameters
    {
        private Orders _orders;

        public Orders Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
        private SqlParameter[] _parameters;

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public OrderUpdateDataParameters(Orders orders)
        {
            Orders = orders;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@OrderId", Orders.OrderId),
                                        new SqlParameter("@OrderStatusId", Orders.OrderStatusId),
                                        new SqlParameter("@ShipDate", Orders.ShipDate),
                                        new SqlParameter("@TrackingNumber", Orders.TrackingNumber)};

            Parameters = parameters;
        }
    }
}
