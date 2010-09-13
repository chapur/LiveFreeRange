using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetWeight : IBusinessLogic
    {
         private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public ProcessGetWeight()
        { }

        public void Invoke()
        {
            WeightSelectData weightData = new WeightSelectData();
            ResultSet = weightData.Get();
        }
    }
}
