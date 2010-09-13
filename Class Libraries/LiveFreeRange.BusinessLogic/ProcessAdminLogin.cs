using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
	public class ProcessAdminLogin : IBusinessLogic
	{
		private EndUser _endUser;
		private DataSet _resultSet;
		private bool _isAuthenticated;

		public ProcessAdminLogin()
		{

		}

		public void Invoke()
		{
			AdminLoginSelectData adminLogin = new AdminLoginSelectData();
			adminLogin.EndUser = this.EndUser;
			ResultSet = adminLogin.Get();

			if ( ResultSet.Tables[ 0 ].Rows.Count != 0 )
			{
				IsAuthenticated = true;
			}
			else
			{
				IsAuthenticated = false;
			}
		}

		public EndUser EndUser
		{
			get { return _endUser; }
			set { _endUser = value; }
		}

		public DataSet ResultSet
		{
			get { return _resultSet; }
			set { _resultSet = value; }
		}

		public bool IsAuthenticated
		{
			get { return _isAuthenticated; }
			set { _isAuthenticated = value; }
		}
	}
}
