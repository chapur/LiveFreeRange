using System.Data;

using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetColour : IBusinessLogic
    {
        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public ProcessGetColour()
        { }

        public void Invoke()
        {
            ColourSelectData colourData = new ColourSelectData();
            ResultSet = colourData.Get();
        }
    }
}
