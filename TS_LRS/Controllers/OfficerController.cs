using Microsoft.AspNetCore.Mvc;

using TS_LRS.Models.Officer;

namespace TS_LRS.Controllers
{
    public class OfficerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Plots_UploadCalculation()
        {
            return View();
        }

        //[HttpPost]
        //public Task<IActionResult> Plots_UploadCalculation(LayoutPlotDtls layoutPlotDtls)
        //{
        //    //return View();
        //}

    }
}
