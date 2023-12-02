using Microsoft.AspNetCore.Mvc;

namespace TS_LRS.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
