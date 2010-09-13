using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess;

namespace LiveFreeRange.DataAccess.Select
{
	public class AdminLoginSelectData : DataAccessBase
	{
		private EndUser _endUser;

		public AdminLoginSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.AdminLogin_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			AdminLoginSelectDataParameters _adminSelectDataParameters = new AdminLoginSelectDataParameters( EndUser );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			ds = dbhelper.Run( base.ConnectionString , _adminSelectDataParameters.Parameters );

			return ds;
		}

		public EndUser EndUser
		{
			get { return _endUser; }
			set { _endUser = value; }
		}
	}

	public class AdminLoginSelectDataParameters
	{
		private EndUser _endUser;
		private SqlParameter[] _parameters;

		public AdminLoginSelectDataParameters( EndUser endUser )
		{
			EndUser = endUser;
			this.Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
		        new SqlParameter( "@Email"		, EndUser.ContactInformation.Email ) ,
				new SqlParameter( "@Password"	, EndUser.Password )
		    };

			Parameters = parameters;
		}

		public EndUser EndUser
		{
			get { return _endUser; }
			set { _endUser = value; }
		}

		public SqlParameter[] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
