using System.Data;

namespace TS_LRS.Repositories.DbConnections.Interfaces
{
    public interface IDapperContext
    {
        IDbConnection GetConnection();

    }
}
