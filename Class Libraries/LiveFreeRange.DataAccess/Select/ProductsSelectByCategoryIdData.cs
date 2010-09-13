using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class ProductsSelectByCategoryIdData : DataAccessBase
    {
        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        private int _categoryId;

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        public ProductsSelectByCategoryIdData()
        
        {
            StoredProcedureName = StoredProcedure.Name.ProductsByCategoryId_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            ProductsSelectByCategoryIdDataParameters _productsSelectByCategoryIdParameters = new ProductsSelectByCategoryIdDataParameters(CategoryId);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _productsSelectByCategoryIdParameters.Parameters);
            return ds;
        }
    }

    public class ProductsSelectByCategoryIdDataParameters
    {
        private Product _product;
        private SqlParameter[] _parameters;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        private int _categoryId;

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public ProductsSelectByCategoryIdDataParameters(int categoryId)
        {
            this.CategoryId = categoryId;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = {new SqlParameter("@ProductCategoryId", this.CategoryId)};
            Parameters = parameters;
        }
    }
}
