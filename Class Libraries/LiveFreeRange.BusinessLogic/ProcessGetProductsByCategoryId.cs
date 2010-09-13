using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;
using System.Data;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetProductsByCategoryId : IBusinessLogic
    {
        private int _categoryId;

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        private DataSet _resultSet;
        
        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        Collection<ProductCollection> _products;

        public Collection<ProductCollection> Products
        {
          get { return _products; }
          set { _products = value; }
        }

        public ProcessGetProductsByCategoryId()
        { }

        public void Invoke()
        {
            ProductsSelectByCategoryIdData selectProducts = new ProductsSelectByCategoryIdData();
            selectProducts.CategoryId = this.CategoryId;
            ResultSet = selectProducts.Get();
            _products = new Collection<ProductCollection>();

            foreach(DataRow dr in ResultSet.Tables[0].Rows)
                _products.Add(new ProductCollection(dr));
        }
    }
}
