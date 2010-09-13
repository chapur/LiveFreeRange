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
    public class ProcessGetProductsByName : IBusinessLogic
    {
        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }
        private string _productName;

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        private int _productColourId;

        public int ProductColourId
        {
            get { return _productColourId; }
            set { _productColourId = value; }
        }

        public ProcessGetProductsByName()
        { }

        public void Invoke()
        {
            ProductsSelectByNameData selectProducts = new ProductsSelectByNameData();
            selectProducts.ProductName = this.ProductName;
            selectProducts.ProductColourId = this.ProductColourId;
            ResultSet = selectProducts.Get();
        }
    }
}
