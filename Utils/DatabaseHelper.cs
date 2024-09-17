using System.Data.SqlClient;
using System;

namespace bleaf_test_automation.Utils
{
    public class DatabaseHelper
    {
        private static DatabaseHelper _instance;
        private readonly SqlConnection _connection;

        private DatabaseHelper()
        {
            _connection = new SqlConnection(ConfigManager.GetConfigValue("ConnectionString"));
        }

        public static DatabaseHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseHelper();
                }
                return _instance;
            }
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public void ExecuteQuery(string query)
        {
            _connection.Execute(query);
        }

        public T QuerySingle<T>(string query)
        {
            return _connection.QuerySingle<T>(query);
        }
    }
}