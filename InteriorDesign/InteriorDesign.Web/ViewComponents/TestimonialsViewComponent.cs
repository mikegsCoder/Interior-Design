using InteriorDesign.Core.Services.Application.AboutUsService;
using InteriorDesign.Core.ViewModels.TestimonialViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.ViewComponents
{
    [ViewComponent(Name = "Testimonials")]
    public class TestimonialsViewComponent : ViewComponent
    {
        private readonly IAboutUsService _aboutUsService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public TestimonialsViewComponent(
            IAboutUsService aboutUsService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<TestimonialsViewComponent> logger)
        {
            _aboutUsService = aboutUsService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public IViewComponentResult Invoke()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var model = _aboutUsService.GetActiveTestimonialsAsync().GetAwaiter().GetResult();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(TestimonialsViewComponent), ": ", ex.Message), ex);
                
                _httpContextAccessor?.HttpContext?.Response.Redirect("/Home/ApplicationError");

                return View(new List<TestimonialViewModel>());
            }
        }
    }
}
