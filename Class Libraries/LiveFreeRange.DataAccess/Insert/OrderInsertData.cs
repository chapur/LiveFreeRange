using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Insert
{
    public class OrderInsertData:DataAccessBase
    {
        private Orders _orders;

        public Orders Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
        private OrderInsertDataParameters _orderInsertDataParameters;

        public OrderInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Order_Insert.ToString();
        }

        public void Add(SqlTransaction transaction)
        {
            _orderInsertDataParameters = new OrderInsertDataParameters(Orders);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            object id = dbHelper.RunScalar(transaction, _orderInsertDataParameters.Parameters);
            Orders.OrderId = int.Parse(id.ToString());
        }

    }

    public class OrderInsertDataParameters
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

        public OrderInsertDataParameters(Orders orders)
        {
            Orders = orders;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@EndUserId", Orders.EndUserId),
                                        new SqlParameter("@TransactionId", Orders.TransactionId)};

            Parameters = parameters;
        }
    }
}
