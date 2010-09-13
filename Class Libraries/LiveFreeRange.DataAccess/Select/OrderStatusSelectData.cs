using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class OrderStatusSelectData : DataAccessBase
    {
        public OrderStatusSelectData()
        {
            base.StoredProcedureName = StoredProcedure.Name.OrderStatus_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            DataBaseHelper dbHelper = new DataBaseHelper(base.StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString);

            return ds;
        }
    }
}
