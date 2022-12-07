using InteriorDesign.Core.Constants;
using InteriorDesign.Core.Services.Application.AboutUsService;
using InteriorDesign.Core.ViewModels.TestimonialViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Administration.ViewComponents
{
    [ViewComponent(Name = "AdminTestimonial")]
    public class AdminTestimonialViewComponent : ViewComponent
    {
        private readonly IAboutUsService _aboutUsService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public AdminTestimonialViewComponent(
            IAboutUsService aboutUsService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<AdminTestimonialViewComponent> logger)
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

                var model = _aboutUsService.GetAllTestimonialsAsync().GetAwaiter().GetResult();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(AdminTestimonialViewComponent), ": ", ex.Message), ex);
                
                TempData["Error"] = ex.Message;

                _httpContextAccessor?.HttpContext?.Response.Redirect(WebConstants.AdminError);

                return View(new List<TestimonialViewModel>());
            }
        }
    }
}
