using System.Data;


namespace LiveFreeRange.DataAccess.Select
{
    public class ColourSelectData : DataAccessBase
    {
        public ColourSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.ProductColour_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(ConnectionString);
            return ds;
        }
    }
}
