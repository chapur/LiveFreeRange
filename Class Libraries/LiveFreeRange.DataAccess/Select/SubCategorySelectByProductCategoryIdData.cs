using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LiveFreeRange.Common;
using System.Data.SqlClient;

namespace LiveFreeRange.DataAccess.Select
{
    public class SubCategorySelectByProductCategoryIdData : DataAccessBase
    {
        private SubCategory _subCategory;

        public SubCategory SubCategory
        {
            get { return _subCategory; }
            set { _subCategory = value; }
        }

        public SubCategorySelectByProductCategoryIdData()
        {
            StoredProcedureName = StoredProcedure.Name.SubCategoryByProductCategoryId_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            SubCategorySelectByProductCategoryIdDataParameters _subCategorySelectByProductCategoryIdParameters = new SubCategorySelectByProductCategoryIdDataParameters(SubCategory);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _subCategorySelectByProductCategoryIdParameters.Parameters);
                
            return ds;
        }
    }

    public class SubCategorySelectByProductCategoryIdDataParameters
    {
        private  SubCategory _subCategory;

        public SubCategory SubCategory
        {
            get { return _subCategory; }
            set { _subCategory = value; }
        }
        private SqlParameter[] _parameters;

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public SubCategorySelectByProductCategoryIdDataParameters(SubCategory subCategory)
        {
            SubCategory = subCategory;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@ProductCategoryId", SubCategory.ProductCategoryId) };
            Parameters = parameters;
        }
    }
}
