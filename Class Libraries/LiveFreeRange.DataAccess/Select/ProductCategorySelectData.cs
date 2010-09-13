using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LiveFreeRange.DataAccess.Select
{
    public class ProductCategorySelectData : DataAccessBase
    {
        public ProductCategorySelectData()
        {
            base.StoredProcedureName = StoredProcedure.Name.ProductCategory_Select.ToString();
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
