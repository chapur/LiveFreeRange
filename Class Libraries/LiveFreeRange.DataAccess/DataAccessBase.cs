using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LiveFreeRange.DataAccess
{
    public class DataAccessBase
    {
        protected string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["SQLCONN"].ToString(); }
        }
        
        private string _storedProcedureName;

        public string StoredProcedureName
        {
            get { return _storedProcedureName; }
            set { _storedProcedureName = value; }
        }
    }
}
