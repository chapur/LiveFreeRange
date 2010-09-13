using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Insert
{
    public class OrderDetailsInsertData : DataAccessBase
    {
        private OrderDetails _orderDetails;

        public OrderDetails OrderDetails
        {
            get { return _orderDetails; }
            set { _orderDetails = value; }
        }
        private OrderDetailsInsertDataParameters _orderDetailsInsertDataParameters;

        public OrderDetailsInsertData()
        {
            OrderDetails = new OrderDetails();
            StoredProcedureName =StoredProcedure.Name.OrderDetails_Insert.ToString();
        }

        public void Add(SqlTransaction transaction)
        {
            _orderDetailsInsertDataParameters = new OrderDetailsInsertDataParameters(OrderDetails);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(transaction, _orderDetailsInsertDataParameters.Parameters);
        }
    }

    public class OrderDetailsInsertDataParameters
    {
        private OrderDetails _orderDetails;

        public OrderDetails OrderDetails
        {
            get { return _orderDetails; }
            set { _orderDetails = value; }
        }
        private SqlParameter[] _parameters;

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public OrderDetailsInsertDataParameters(OrderDetails orderDetails)
        {
            OrderDetails = orderDetails;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@OrderId", OrderDetails.OrderId),
                                        new SqlParameter("@ProductId", OrderDetails.ProductId),
                                        new SqlParameter("@Quantity", OrderDetails.Quantity)};

            Parameters = parameters;
        }
    }
}
