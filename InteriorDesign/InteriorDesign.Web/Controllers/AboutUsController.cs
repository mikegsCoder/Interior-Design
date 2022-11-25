using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Controllers
{
    public class AboutUsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
