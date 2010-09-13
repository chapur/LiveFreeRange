using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;


namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetProductsBySubCategoryId : IBusinessLogic
    {
        private int _subCategoryId;
        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public int SubCategoryId
        {
            get { return _subCategoryId; }
            set { _subCategoryId = value; }
        }

        private Collection<ProductCollection> _products;

        public Collection<ProductCollection> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public ProcessGetProductsBySubCategoryId()
        {
        
        }

        public void Invoke()
        {
            ProductsSelectBySubCategoryIdData productData = new ProductsSelectBySubCategoryIdData();
            productData.SubCategoryId = this.SubCategoryId;
            ResultSet = productData.Get();

            _products = new Collection<ProductCollection>();
            foreach (DataRow dr in ResultSet.Tables[0].Rows)
            { 
                _products.Add(new ProductCollection(dr));
            }
        }
    }
}
