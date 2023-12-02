using Microsoft.AspNetCore.Mvc;

namespace TS_LRS.Controllers
{
    public class DownLoadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowDownloadPDF(string fileName)
        {
            // Define the file path           
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Documents\\" + fileName);

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); // Handle the case where the file doesn't exist
            }
            return PhysicalFile(filePath, "application/pdf");
        }

    }
}
