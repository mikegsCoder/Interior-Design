using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Controllers
{
    public class GalleryController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
