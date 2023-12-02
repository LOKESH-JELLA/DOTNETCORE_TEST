using Microsoft.AspNetCore.Mvc;

namespace TS_LRS.Controllers
{
    public class CitizenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
