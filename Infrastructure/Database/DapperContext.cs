using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Questao5.Infrastructure.Database
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext()
        {
            
        }

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            string _connectionString = _configuration["DatabaseName"];
            return new SqliteConnection(_connectionString);
        }
    }
}