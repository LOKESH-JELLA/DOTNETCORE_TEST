using TS_LRS.Repositories.DbConnections.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace TS_LRS.Repositories.DbConnections
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString_PDL;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;

            _connectionString_PDL = _configuration.GetConnectionString("conStrLRS");
        }
        public IDbConnection GetConnection()
            => new OracleConnection(_connectionString_PDL);

    }
}
