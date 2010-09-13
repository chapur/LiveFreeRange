using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;
using System.Data;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetSubCategoryByProductCategoryId :IBusinessLogic
    {
        public ProcessGetSubCategoryByProductCategoryId()
        { 
        
        }

        private SubCategory _subCategory;

        public SubCategory SubCategory
        {
            get { return _subCategory; }
            set { _subCategory = value; }
        }

        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public void Invoke()
        {
            SubCategorySelectByProductCategoryIdData selectSubCategory = new SubCategorySelectByProductCategoryIdData();
            selectSubCategory.SubCategory = SubCategory;
            ResultSet = selectSubCategory.Get();

            SubCategory.SubCategoryName = ResultSet.Tables[0].Rows[0]["SubCategoryName"].ToString();
            SubCategory.SubCategoryDisplayName = ResultSet.Tables[0].Rows[0]["SubCategoryDisplayName"].ToString();
            SubCategory.ProductCategoryId = Convert.ToInt32(ResultSet.Tables[0].Rows[0]["ProductCategoryId"]);
        }
    }
}
