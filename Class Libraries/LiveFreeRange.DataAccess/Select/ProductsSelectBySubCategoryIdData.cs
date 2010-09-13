using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class ProductsSelectBySubCategoryIdData : DataAccessBase
    {
        private int _subCategoryId;

        public int SubCategoryId
        {
            get { return _subCategoryId; }
            set { _subCategoryId = value; }
        }

        public ProductsSelectBySubCategoryIdData()
        {
            StoredProcedureName = StoredProcedure.Name.ProductsBySubCategoryId_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            ProductsSelectBySubCategoryIdDataParameters _productSelectPatameters = new ProductsSelectBySubCategoryIdDataParameters(SubCategoryId);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(ConnectionString, _productSelectPatameters.Parameters);
            return ds;
        }
    }

    public class ProductsSelectBySubCategoryIdDataParameters
    {
        private int _subCategory;
        private SqlParameter[] _parameters;

        public int SubCategory
        {
            get { return _subCategory; }
            set { _subCategory = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public ProductsSelectBySubCategoryIdDataParameters(int subCategoryId)
        {
            this.SubCategory = subCategoryId;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@SubCategoryId", SubCategory)};
            this.Parameters = parameters;
        }
    }
}
