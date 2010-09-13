using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetSize : IBusinessLogic
    {
         private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public ProcessGetSize()
        { }

        public void Invoke()
        {
            SizeSelectData sizeData = new SizeSelectData();
            ResultSet = sizeData.Get();
        }
    }
}
