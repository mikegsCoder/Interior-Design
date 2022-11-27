using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Controllers
{
    public class OurTeamController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
