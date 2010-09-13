using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class ProductCategorySelectByIdData :DataAccessBase
    {
        private ProductCategory _productCategory;

        public ProductCategory ProductCategory
        {
            get { return _productCategory; }
            set { _productCategory = value; }
        }

        public ProductCategorySelectByIdData()
        {
            base.StoredProcedureName = StoredProcedure.Name.ProductCategoryById_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            ProductCategorySelectByIdDataParamters _productCategorySelectByIdParameters = new ProductCategorySelectByIdDataParamters(ProductCategory);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _productCategorySelectByIdParameters.Parameters);

            return ds;
        }
    }

    public class ProductCategorySelectByIdDataParamters
    {
        private ProductCategory _productCategory;

        public ProductCategory ProductCategory
        {
            get { return _productCategory; }
            set { _productCategory = value; }
        }
        private SqlParameter[] _parameters;

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public ProductCategorySelectByIdDataParamters(ProductCategory productCategory)
        {
            ProductCategory = productCategory;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@ProductCategoryId", ProductCategory.ProductCategoryId) };
            Parameters = parameters;
        }
    }
}
