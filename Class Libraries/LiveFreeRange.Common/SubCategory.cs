using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class SubCategory
    {
        public SubCategory()
        { }

        private string _subCategoryName;

        public string SubCategoryName
        {
            get { return _subCategoryName; }
            set { _subCategoryName = value; }
        }

        private string _subCategoryDisplayName;

        public string SubCategoryDisplayName
        {
            get { return _subCategoryDisplayName; }
            set { _subCategoryDisplayName = value; }
        }

        private int _subCategoryId;

        public int SubCategoryId
        {
            get { return _subCategoryId; }
            set { _subCategoryId = value; }
        }

        private int _productCategoryId;

        public int ProductCategoryId
        {
            get { return _productCategoryId; }
            set { _productCategoryId = value; }
        }
    }
}
