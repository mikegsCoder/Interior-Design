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

        [HttpGet]
        public async Task<IActionResult> Deactivate(string testimonialId)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception");

                await _aboutUsService.DeactivateTestimonialAsync(testimonialId);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(TestimonialsController), nameof(Deactivate));
            }
        }
    }
}
