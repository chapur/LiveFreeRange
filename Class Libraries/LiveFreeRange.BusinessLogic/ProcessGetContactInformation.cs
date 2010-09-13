using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;
using LiveFreeRange.BusinessLogic;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetContactInformation : IBusinessLogic
	{
		private DataSet _resultSet;
		private ContactInformation _contactInformation;

		public ProcessGetContactInformation()
		{
			_contactInformation = new ContactInformation();
		}

		public void Invoke()
		{
			ContactInformationSelectData contactData = new ContactInformationSelectData();
			contactData.ContactInformation = this.ContactInformation;
			ResultSet = contactData.Get();

			ContactInformation.ContactInformationId = int.Parse( ResultSet.Tables[0].Rows[0]["ContactInformationId"].ToString() );
			ContactInformation.Phone = ResultSet.Tables[0].Rows[0]["Phone"].ToString();
			ContactInformation.Phone2 = ResultSet.Tables[0].Rows[0]["Phone2"].ToString();
			ContactInformation.Fax = ResultSet.Tables[0].Rows[0]["Fax"].ToString();
			ContactInformation.Email = ResultSet.Tables[0].Rows[0]["Email"].ToString();
		}

		public ContactInformation ContactInformation
		{
			get { return _contactInformation; }
			set { _contactInformation = value; }
		}

		public DataSet ResultSet
		{
			get { return _resultSet; }
			set { _resultSet = value; }
		}
	}
}
