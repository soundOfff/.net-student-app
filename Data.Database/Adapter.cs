using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        const string consKeyDefaultCnnString = "ConnStringLocal";

        private SqlConnection _sqlConn;
        public SqlConnection SqlConn { get { return _sqlConn;  } set { _sqlConn = value;  } }

        protected void OpenConnection()
        {
            var _connectioString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            _sqlConn = new SqlConnection(_connectioString);
            _sqlConn.Open();
        }

        protected void CloseConnection()
        {
            _sqlConn.Close();
            _sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
