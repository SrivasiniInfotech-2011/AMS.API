using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
namespace AMS.API.Repositories
{
    public class DapperContext : IDapperContext
    {
        private string _connectionString;
        private object obj= new object();
        private SqlConnection _sqlConnection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="connectionString"></param>
        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Get the ConnectionString.
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetSqlConnection()
        {
            lock (obj)
            {
                if (_sqlConnection == null)
                    _sqlConnection = new SqlConnection(_connectionString);
            }
            return _sqlConnection;
        }
    }
}
