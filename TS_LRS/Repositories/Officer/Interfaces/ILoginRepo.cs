using TS_LRS.Models.Login;

namespace TS_LRS.Repositories.Officer.Interfaces
{
    public interface ILoginRepo
    {
        Task<LoggedUser> GetLoginAsyn(LoginUser loginUser);

    }
}
