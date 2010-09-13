using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class OrderDetailsSelectData : DataAccessBase
    {
        private OrderDetails _orderDetails;

        public OrderDetails OrderDetails
        {
            get { return _orderDetails; }
            set { _orderDetails = value; }
        }

        public OrderDetailsSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.OrderDetails_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;

            OrderDetailsSelectDataParameters _orderDetailsSelectDataParamters = new OrderDetailsSelectDataParameters(OrderDetails);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _orderDetailsSelectDataParamters.Parameters);
            
            return ds;
        }
    }

    public class OrderDetailsSelectDataParameters
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

        public OrderDetailsSelectDataParameters(OrderDetails orderDetails)
        {
            OrderDetails = orderDetails;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = {new SqlParameter("@OrderId", OrderDetails.OrderId)};

            Parameters = parameters;
        }
    }
}
