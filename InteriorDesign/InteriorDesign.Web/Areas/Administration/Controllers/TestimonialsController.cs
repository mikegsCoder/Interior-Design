using InteriorDesign.Core.Services.Application.AboutUsService;
using InteriorDesign.Web.Areas.Administration.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Administration.Controllers
{
    public class TestimonialsController : BaseAdminController
    {
        private readonly IAboutUsService _aboutUsService;
        private readonly ILogger _logger;

        public TestimonialsController(
            IAboutUsService aboutUsService, 
            ILogger<TestimonialsController> logger)
        {
            _aboutUsService = aboutUsService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
