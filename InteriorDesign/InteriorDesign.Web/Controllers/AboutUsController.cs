using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Controllers
{
    public class AboutUsController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
