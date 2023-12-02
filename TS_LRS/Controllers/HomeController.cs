using TS_LRS.Models;
using TS_LRS.Utilities.NLogs.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TS_LRS.Services.Website.Interfaces;

namespace TS_LRS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _logger;
        private readonly IConfiguration _configuration;
        private readonly IHomeService _homeService;

        public HomeController(ILog logger, IConfiguration configuration, IHomeService homeService)
        {
            _logger = logger;
            _configuration = configuration;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            _logger.Information("Index");
            try
            {

            }
            catch (Exception ex)
            {               
                _logger.Error(ex.Message);
            }
            return View();
        }

        public IActionResult Citizen()
        {
            _logger.Information("Index");
            try
            {

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            return View();
        }
        public IActionResult AboutUs()
        {
            _logger.Information("AboutUs");
            try
            {

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            return View();
        }
        public IActionResult GOs()
        {
            _logger.Information("GOs");
            try
            {

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            return View();
        }
        public IActionResult FAQs()
        {
            _logger.Information("FAQs");
            try
            {

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            return View();
        }

    }
}