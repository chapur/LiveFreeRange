using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;

namespace LiveFreeRange.DataAccess
{
   public class DataBaseHelper : DataAccessBase
    {
        private SqlParameter[] _parameters;

        public DataBaseHelper(string storedProcedureName)
        {
            StoredProcedureName = storedProcedureName;
        }

        public void Run(SqlTransaction transaction)
        {
            SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, StoredProcedureName, Parameters);
        }

        public void Run(SqlTransaction transaction, SqlParameter[] parameters)
        {
            SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, StoredProcedureName, parameters);
        }

        public DataSet Run(string connectionString, SqlParameter[] parameters)
        {
            DataSet ds = SqlHelper.ExecuteDataset(connectionString, StoredProcedureName, parameters);
            return ds;
        }

        public object RunScalar(string connectionString, SqlParameter[] parameters)
        {
            object obj = SqlHelper.ExecuteScalar(connectionString, StoredProcedureName, parameters);
            return obj;
        }

        public object RunScalar(SqlTransaction transaction, SqlParameter[] parameters)
        {
            object obj = SqlHelper.ExecuteScalar(transaction, StoredProcedureName, parameters);
            return obj;
        }

        public DataSet Run(string connectionString)
        {
            DataSet ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, StoredProcedureName);
            return ds;
        }

        public void Run()
        {
            SqlHelper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, StoredProcedureName, Parameters);
        }

        public SqlDataReader Run(SqlParameter[] parameters)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.StoredProcedure, StoredProcedureName, parameters);
            return dr;
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

    }
}
