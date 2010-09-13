using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class ContactInformationSelectData : DataAccessBase
	{
		private ContactInformation _contactInformation;
       
        public ContactInformation ContactInformation
		{
			get { return _contactInformation; }
			set { _contactInformation = value; }
		}

		public ContactInformationSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.ContactInformation_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			ContactInformationSelectDataParameters _contactInformationSelectDataParameters = new ContactInformationSelectDataParameters( ContactInformation );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
            ds = dbhelper.Run(base.ConnectionString, _contactInformationSelectDataParameters.Parameters);

			return ds;
		}
	}

	public class ContactInformationSelectDataParameters
	{
		private ContactInformation _contactInformation;
		private SqlParameter[] _parameters;
        
        public ContactInformation ContactInformation
		{
			get { return _contactInformation; }
			set { _contactInformation = value; }
		}

		public SqlParameter[] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
        }

		public ContactInformationSelectDataParameters( ContactInformation contactInformation )
		{
			ContactInformation = contactInformation;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
		        new SqlParameter( "@ContactInformationId" , ContactInformation.ContactInformationId ) 
		    };

			Parameters = parameters;
		}
	}
}
