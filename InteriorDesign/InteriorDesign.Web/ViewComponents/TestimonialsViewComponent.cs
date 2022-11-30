using InteriorDesign.Core.Services.Application.AboutUsService;
using InteriorDesign.Core.ViewModels.TestimonialViewModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.ViewComponents
{
    [ViewComponent(Name = "Testimonials")]
    public class TestimonialsViewComponent : ViewComponent
    {
        private readonly IAboutUsService _aboutUsService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;

        public TestimonialsViewComponent(
            IAboutUsService aboutUsService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<TestimonialsViewComponent> logger,
            IMemoryCache cache)
        {
            _aboutUsService = aboutUsService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _cache = cache;
        }

        public IViewComponentResult Invoke()
        {
            if (!_cache.TryGetValue<IEnumerable<TestimonialViewModel>>("Testimonials", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = _aboutUsService.GetActiveTestimonialsAsync().GetAwaiter().GetResult();

                    _cache.Set("Testimonials", model, TimeSpan.FromMinutes(5));
                }
                catch (Exception ex)
                {
                    _logger.LogError(string.Concat(nameof(TestimonialsViewComponent), ": ", ex.Message), ex);

                    _httpContextAccessor?.HttpContext?.Response.Redirect("/Home/ApplicationError");

                    return View(new List<TestimonialViewModel>());
                }
            }

            return View(model);
        }
    }
}
