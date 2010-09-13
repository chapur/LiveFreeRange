using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Update
{
    public class NewsletterUpdateData : DataAccessBase
    {
        private EndUser _endUser;

        public EndUser EndUser
        {
            get { return _endUser; }
            set { _endUser = value; }
        }
        private NewsletterUpdateDataParameters _newsletterUpdateDataParameters;

        public NewsletterUpdateData()
        {
            base.StoredProcedureName = StoredProcedure.Name.NewsletterUnsubscribe_Update.ToString();
        }

        public void Update()
        {
            _newsletterUpdateDataParameters = new NewsletterUpdateDataParameters(EndUser);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Parameters = _newsletterUpdateDataParameters.Parameters;
            dbHelper.Run();
        }
    }

    public class NewsletterUpdateDataParameters
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

        public NewsletterUpdateDataParameters(EndUser endUser)
        {
            EndUser = endUser;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@EndUserId", EndUser.EndUserId)};

            Parameters = parameters;
        }
    }
}
