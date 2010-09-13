using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LiveFreeRange.DataAccess.Select
{
    public class ProductStockLevelSelectByIdData : DataAccessBase
    {
        public int ProductId { get; set; }

        public ProductStockLevelSelectByIdData()
        {
            StoredProcedureName = StoredProcedure.Name.ProductStockLevelById_Select.ToString();                
        }

        public DataSet Get()
        {
            DataSet ds;
            ProductStockLevelSelectByIdDataParameters _productStockLevelSelectByIdParameters = new ProductStockLevelSelectByIdDataParameters(ProductId);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _productStockLevelSelectByIdParameters.Parameters);
            return ds;
        }
    }

    public class ProductStockLevelSelectByIdDataParameters
    {
        private int _productId;
        private SqlParameter[] _parameters;
       
        public int ProductId { get; set; }
        public SqlParameter[] Parameters { get; set; }

        public ProductStockLevelSelectByIdDataParameters(int productId)
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
