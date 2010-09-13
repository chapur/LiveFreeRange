using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class OrdersSelectByIdData : DataAccessBase
    {
        private Orders _orders;

        public Orders Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public OrdersSelectByIdData()
        {
            StoredProcedureName = StoredProcedure.Name.OrdersById_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;

            OrderSelectDataByIdParamters _orderSelectDataByIdParameters = new OrderSelectDataByIdParamters(Orders);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _orderSelectDataByIdParameters.Parameters);

            return ds;
        }
    }

    public class OrderSelectDataByIdParamters
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

        public OrderSelectDataByIdParamters(Orders orders)
        {
            Orders = orders;
            this.Build();
        }

        private void Build()
        { 
            SqlParameter[] parameters = {new SqlParameter("@OrderId", Orders.OrderId)};

            Parameters = parameters;
        }
    }
}
