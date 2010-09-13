using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;
using LittleItalyVineyard.BusinessLogic;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessEndUserLogin : IBusinessLogic
    {
        private EndUser _endUser;

        public EndUser EndUser
        {
            get { return _endUser; }
            set { _endUser = value; }
        }
        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }
        private bool _IsAuthenticated;

        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
            set { _IsAuthenticated = value; }
        }

        public ProcessEndUserLogin()
        { 
        
        }

        public void Invoke()
        {
            EndUserLoginSelectData endUserLogin = new EndUserLoginSelectData();
            endUserLogin.EndUser = this.EndUser;
            this.ResultSet = endUserLogin.Get();

            if (ResultSet.Tables[0].Rows.Count != 0)
            {
                this.IsAuthenticated = true;

                this.EndUser.EndUserId = int.Parse(ResultSet.Tables[0].Rows[0]["EndUserId"].ToString());
                this.EndUser.EndUserTypeId = int.Parse(ResultSet.Tables[0].Rows[0]["EndUserTypeId"].ToString());
                this.EndUser.FirstName = ResultSet.Tables[0].Rows[0]["FirstName"].ToString();
                this.EndUser.LastName = ResultSet.Tables[0].Rows[0]["LastName"].ToString();
                this.EndUser.AddressId = int.Parse(ResultSet.Tables[0].Rows[0]["AddressId"].ToString());
                this.EndUser.ContactInformationId = int.Parse(ResultSet.Tables[0].Rows[0]["ContactInformationId"].ToString());
                this.EndUser.Password = ResultSet.Tables[0].Rows[0]["Password"].ToString();
                
                //obtain the Address information
                ProcessGetContactInformation getContactInformation = new ProcessGetContactInformation();
                getContactInformation.ContactInformation.ContactInformationId = EndUser.ContactInformationId;

                getContactInformation.Invoke();

                EndUser.ContactInformation = getContactInformation.ContactInformation;
            }
            else
            {
                EndUser = null;
                IsAuthenticated = false;
            }
        }
    }
}
