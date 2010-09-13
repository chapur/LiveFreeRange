using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class OrdersSelectData : DataAccessBase
    {
        private EndUser _endUser;

        public EndUser EndUser
        {
            get { return _endUser; }
            set { _endUser = value; }
        }

        public OrdersSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Orders_Select.ToString();       
        }

        public DataSet Get()
        {
            DataSet ds;

            OrdersSelectDataParameters _ordersSelectDataParameters = new OrdersSelectDataParameters(EndUser);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _ordersSelectDataParameters.Parameters);

            return ds;

        }
    }

    public class OrdersSelectDataParameters
    {
        private EndUser _endUser;

        public EndUser EndUser
        {
            get { return _endUser; }
            set { _endUser = value; }
        }
        private SqlParameter[] _parameters;

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public OrdersSelectDataParameters(EndUser endUser)
        {
            EndUser = endUser;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@EndUserId", EndUser.EndUserId)};
            Parameters = parameters;
        }
    }
}
