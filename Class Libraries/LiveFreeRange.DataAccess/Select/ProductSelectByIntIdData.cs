using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LiveFreeRange.DataAccess.Select
{
    public class ProductSelectByIntIdData : DataAccessBase
    {
        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public ProductSelectByIntIdData()
        {
            StoredProcedureName = StoredProcedure.Name.ProductById_SelectNew.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            ProductSelectByIntIdDataParamters _productSelectByIdParameters = new ProductSelectByIntIdDataParamters(ProductId);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _productSelectByIdParameters.Parameters);
            return ds;
        }
    }

    public class ProductSelectByIntIdDataParamters
    {
        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
        private SqlParameter[] _parameters;

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public ProductSelectByIntIdDataParamters(int productId)
        {
            ProductId = productId;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@ProductID", ProductId) };
            Parameters = parameters;
        }
    }
}
