using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class EndUserLoginSelectData : DataAccessBase
    {
        private EndUser _endUser;

        public EndUser EndUser
        {
            get { return _endUser; }
            set { _endUser = value; }
        }

        public EndUserLoginSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.EndUserLogin_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            EndUserLoginSelectDataParameters _endUserSelectDataParameters = new EndUserLoginSelectDataParameters(EndUser);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _endUserSelectDataParameters.Parameters);
            return ds;
        }
    }

    public class EndUserLoginSelectDataParameters
    {
        private EndUser _endUser;

        public EndUser EndUser
        {
            get { return _endUser; }
            set { _endUser = value; }
        }
        private SqlParameter[] _parameters;

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public EndUserLoginSelectDataParameters(EndUser endUser)
        {
            EndUser = endUser;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = {new SqlParameter("@Email", EndUser.ContactInformation.Email),
                                        new SqlParameter("@Password", EndUser.Password)};
            Parameters = parameters;
        }
    }
}
