using Dapper;
using TS_LRS.Models.Login;
using TS_LRS.Repositories.DbConnections.Interfaces;
using TS_LRS.Repositories.Helpers;

using Oracle.ManagedDataAccess.Client;
using System.Data;
using TS_LRS.Repositories.Officer.Interfaces;

namespace TS_LRS.Repositories.Officer
{
    public class LoginRepo : ILoginRepo
    {
        private readonly IDapperContext _connectionFactory;
        public LoginRepo(IDapperContext connectionFactory, IHttpContextAccessor httpContextAccessor)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<LoggedUser> GetLoginAsyn(LoginUser loginUser)
        {
            LoggedUser loggedUser = new LoggedUser();
            try
            {
                using (var cnn = _connectionFactory.GetConnection())
                {
                    cnn.Open();
                    var p = new OracleDynamicParameters();

                    p.Add("P_USERNAME", loginUser.USRNAME);
                    p.Add("P_PASSWORD", loginUser.PASSWORD);
                    p.Add("P_SESSIONID", loginUser.SESSIONID);
                    p.Add("P_RECORDS", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                    loggedUser = await cnn.QueryFirstOrDefaultAsync<LoggedUser>("LRS_GET_LAYOUT_USER_DTLS_USP", param: p, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                string message = ex.ToString();
                throw ex;
            }
            return loggedUser;
        }

    }
}
