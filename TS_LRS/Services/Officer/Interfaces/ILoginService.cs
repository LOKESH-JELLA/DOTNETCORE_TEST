using TS_LRS.Models.Login;

namespace TS_LRS.Services.Officer.Interfaces
{
    public interface ILoginService
    {
        Task<LoggedUser> GetLoginAsyn(LoginUser loginUser);

    }
}
