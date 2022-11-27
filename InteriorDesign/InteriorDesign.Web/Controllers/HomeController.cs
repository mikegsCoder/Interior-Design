using InteriorDesign.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InteriorDesign.Web.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NotFound404()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ApplicationError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cookies()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}