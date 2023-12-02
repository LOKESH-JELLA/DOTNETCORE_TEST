using TS_LRS.Models.Login;
using TS_LRS.Repositories.Officer.Interfaces;
using TS_LRS.Services.Officer.Interfaces;

namespace TS_LRS.Services.Officer
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _loginReposi;
        public LoginService(ILoginRepo loginReposi)
        {
            _loginReposi = loginReposi;
        }

        public Task<LoggedUser> GetLoginAsyn(LoginUser loginUser)
        {
            return _loginReposi.GetLoginAsyn(loginUser);
        }

    }
}
