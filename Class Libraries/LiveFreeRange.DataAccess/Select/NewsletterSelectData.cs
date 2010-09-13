using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LiveFreeRange.DataAccess.Select
{
    public class NewsletterSelectData : DataAccessBase
    {
        public NewsletterSelectData()
        {
            base.StoredProcedureName = StoredProcedure.Name.Newsletter_Select.ToString();
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
