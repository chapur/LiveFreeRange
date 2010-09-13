using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class ProductSelectByProductIdData : DataAccessBase
    {
        private Product _product;
        private ProductSize _productSize;

        public ProductSize ProductSize
        {
            get { return _productSize; }
            set { _productSize = value; }
        }

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public ProductSelectByProductIdData()
        {
            StoredProcedureName = StoredProcedure.Name.ProductById_SelectNew.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            ProductSelectByProductIdDataParamters _productSelectByIdParameters = new ProductSelectByProductIdDataParamters(Product);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _productSelectByIdParameters.Parameters);
            return ds;
        }
    }

    public class ProductSelectByProductIdDataParamters
    {
        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
        private SqlParameter[] _parameters;

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public ProductSelectByProductIdDataParamters(Product product)
        {
            Product = product;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@ProductID", Product.ProductId) };
            Parameters = parameters;
        }
    }
}
