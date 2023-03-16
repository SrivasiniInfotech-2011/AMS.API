using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
namespace AMS.API.Repositories
{
    public interface IDapperContext
    {
        public SqlConnection GetSqlConnection();
    }
}
