using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
	public class OrdersAllSelectData : DataAccessBase
	{
		public OrdersAllSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.OrdersAll_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			DataBaseHelper dbHelper = new DataBaseHelper( base.StoredProcedureName );
			ds = dbHelper.Run( base.ConnectionString );

			return ds;
		}
	}
}
