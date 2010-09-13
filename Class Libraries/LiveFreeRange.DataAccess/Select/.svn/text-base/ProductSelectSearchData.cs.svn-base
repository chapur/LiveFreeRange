using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LiveFreeRange.DataAccess.Select
{
    public class ProductSelectSearchData : DataAccessBase
    {
        private string _searchCriteria;

        public string SearchCriteria
        {
            get { return _searchCriteria; }
            set { _searchCriteria = value; }
        }

        public ProductSelectSearchData()
        {
            base.StoredProcedureName = StoredProcedure.Name.Products_SelectSearch.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;

            ProductSelectSearchDataParameters _productSelectSearchDataParameters = new ProductSelectSearchDataParameters(SearchCriteria);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _productSelectSearchDataParameters.Parameters);
            return ds;
        }
    }

    public class ProductSelectSearchDataParameters
    {
        private string _searchCriteria;

        public string SearchCriteria
        {
            get { return _searchCriteria; }
            set { _searchCriteria = value; }
        }

        private SqlParameter[] _parameters;

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public ProductSelectSearchDataParameters(string searchCriteria)
        {
            SearchCriteria = searchCriteria;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@SearchCriteria", SearchCriteria) };

            Parameters = parameters;
        }
    }
}
