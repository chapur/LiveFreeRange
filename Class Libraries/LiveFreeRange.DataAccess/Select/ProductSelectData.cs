using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LiveFreeRange.DataAccess.Select
{
    public class ProductSelectData : DataAccessBase
    {
        public ProductSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Products_Select.ToString();
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
