using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class ProductNamesSelectData : DataAccessBase
    {
        public ProductNamesSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.ProductName_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(ConnectionString);
            return ds;
        }
    }
}
