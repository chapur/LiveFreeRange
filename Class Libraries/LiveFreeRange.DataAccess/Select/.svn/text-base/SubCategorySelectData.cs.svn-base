using System.Data;

namespace LiveFreeRange.DataAccess.Select
{
    public class SubCategorySelectData : DataAccessBase
    {
        public SubCategorySelectData()
        {
            base.StoredProcedureName = StoredProcedure.Name.SubCategory_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            DataBaseHelper dbHelper = new DataBaseHelper(base.StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString);

            return ds;
        }
    }
}
