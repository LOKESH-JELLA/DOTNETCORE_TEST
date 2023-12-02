using TS_LRS.Models.Login;
using TS_LRS.Utilities.NLogs.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TS_LRS.Services.Officer.Interfaces;
using TS_LRS.Services.Website.Interfaces;

namespace TS_LRS.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILog _logger;
        private readonly IConfiguration _configuration;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly IHomeService _homeService;
       
        private readonly ILoginService _loginService;

        public LoginController(ILog logger, IConfiguration configuration, IHomeService homeService)
        {
            _logger = logger;
            _configuration = configuration;
            _homeService = homeService;
        }
      
        public IActionResult Login()
        {

            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Login(LoginUser loginUser)
        {
            try
            {
                string usercapcha = "";
                string gencapcha = "";
                if (usercapcha == gencapcha)
                {
                    //loginUser.IP_ADDRESS = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    LoggedUser loggedUser = await _loginService.GetLoginAsyn(loginUser);
                    if (loggedUser != null)
                    {
                        //_httpContextAccessor.HttpContext.Session.SetString("c_chng_pwd", loggedUser.C_CHNG_PWD);
                        //_httpContextAccessor.HttpContext.Session.SetString("is_loggedin", "yes");
                        //_httpContextAccessor.HttpContext.Session.SetString("roleid", loggedUser.I_ROLEID);
                        //_httpContextAccessor.HttpContext.Session.SetString("userid", loggedUser.I_USRID.ToString());
                        //_httpContextAccessor.HttpContext.Session.SetString("username", loggedUser.USER_NAME);
                        //_httpContextAccessor.HttpContext.Session.SetString("role", loggedUser.vc_rolename);

                       // return RedirectToAction("Dashboard", "Home");
                    }
                    else
                    {
                        TempData["LoginMessage"] = "Access Denied! Wrong Credentials";
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    TempData["LoginMessage"] = "Please enter Valid Captcha.";
                }
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                _logger.Information("Login");
                _logger.Error(ex.Message);
                TempData["LoginMessage"] = "Please enter Valid Captcha.";
                return RedirectToAction("Login");
            }
        }

        public IActionResult LayoutLogin()
        {
            return View();
        }

    }
}
