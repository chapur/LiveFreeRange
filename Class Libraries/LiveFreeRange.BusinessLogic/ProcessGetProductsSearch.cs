using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetProductsSearch : IBusinessLogic
    {
        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }
        private string _searchCriteria;

        public string SearchCriteria
        {
            get { return _searchCriteria; }
            set { _searchCriteria = value; }
        }

        public ProcessGetProductsSearch()
        { }

        public void Invoke()
        {
            ProductSelectSearchData productDataSearch = new ProductSelectSearchData();
            productDataSearch.SearchCriteria = this.SearchCriteria;
            ResultSet = productDataSearch.Get();
        }
    }
}
