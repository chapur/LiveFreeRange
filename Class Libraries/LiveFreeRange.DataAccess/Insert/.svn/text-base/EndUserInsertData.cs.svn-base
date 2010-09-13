using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Insert
{
    public class EndUserInsertData : DataAccessBase
    {
        private EndUser _endUser;

        public EndUser EndUser
        {
            get { return _endUser; }
            set { _endUser = value; }
        }

        private EndUserInsertDataParameters _endUserInsertDataParameters;

        public EndUserInsertDataParameters EndUserInsertDataParameters
        {
            get { return _endUserInsertDataParameters; }
            set { _endUserInsertDataParameters = value; }
        }

        public EndUserInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.EndUser_Insert.ToString();
        }

        public void Add()
        {
            _endUserInsertDataParameters = new EndUserInsertDataParameters(EndUser);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            object id = dbHelper.RunScalar(base.ConnectionString, _endUserInsertDataParameters.Parameters);
            EndUser.EndUserId = int.Parse(id.ToString());
        }
    }

    public class EndUserInsertDataParameters
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

        public EndUserInsertDataParameters(EndUser endUser)
        {
            EndUser = endUser;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = {new SqlParameter("@FirstName", EndUser.FirstName),
                                            new SqlParameter("@LastName", EndUser.LastName),
                                            new SqlParameter("@AddressLine", EndUser.Address.AddressLine),
                                            new SqlParameter("@AddressLine2", EndUser.Address.AddressLine2),
                                            new SqlParameter("@City", EndUser.Address.City),
                                            new SqlParameter("@PostalCode", EndUser.Address.PostalCode),
                                            new SqlParameter("@Phone", EndUser.ContactInformation.Phone),
                                            new SqlParameter("@Phone2", EndUser.ContactInformation.Phone2),
                                            new SqlParameter("@Fax", EndUser.ContactInformation.Fax),
                                            new SqlParameter("@Email", EndUser.ContactInformation.Email),
                                            new SqlParameter("@EndUserTypeId", EndUser.EndUserTypeId),
                                            new SqlParameter("@Password", EndUser.Password),
                                            new SqlParameter("@IsSubscribed", EndUser.IsSubscribed)};

            Parameters = parameters;
        }

    }
}
