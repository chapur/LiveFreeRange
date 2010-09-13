using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class ShowcaseSelectByPageIdData : DataAccessBase
    {
        private int _pageId;

        public int PageId
        {
            get { return _pageId; }
            set { _pageId = value; }
        }

        public ShowcaseSelectByPageIdData()
        {
            StoredProcedureName = StoredProcedure.Name.ShowcaseByPageId_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            ShowcaseSelectByPageIdDataParameters _shocaseSelectByPageIdParameters = new ShowcaseSelectByPageIdDataParameters(PageId);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _shocaseSelectByPageIdParameters.Parameters);
            return ds;
        }
    }

    public class ShowcaseSelectByPageIdDataParameters
    {
        private SqlParameter[] _parameters;
        private int _pageId;

        public int PageId
        {
            get { return _pageId; }
            set { _pageId = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public ShowcaseSelectByPageIdDataParameters(int pageId)
        {
            PageId = pageId;
            this.Build();
        }

        private void Build()
        { 
            SqlParameter[] parameters = {new SqlParameter("PageId", PageId) };
            Parameters = parameters;
        }
    }
}
