using InteriorDesign.Core.Services.Application.GalleryService;
using InteriorDesign.Core.ViewModels.DesignImageViewModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.ViewComponents
{
    [ViewComponent(Name = "Gallery")]
    public class DashboardViewComponent : ViewComponent
    {
        private readonly IGalleryService _galleryService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;

        public DashboardViewComponent(
            IGalleryService galleryService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<DashboardViewComponent> logger,
            IMemoryCache cache)
        {
            _galleryService = galleryService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _cache = cache;
        }

        public IViewComponentResult Invoke()
        {
            if (!_cache.TryGetValue<IEnumerable<DesignImageViewModel>>("Gallery", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = _galleryService.GetActiveImagesAsync().GetAwaiter().GetResult();

                    _cache.Set("Gallery", model, TimeSpan.FromMinutes(5));
                }
                catch (Exception ex)
                {
                    _logger.LogError(string.Concat(nameof(DashboardViewComponent), ": ", ex.Message), ex);

                    _httpContextAccessor?.HttpContext?.Response.Redirect("/Home/ApplicationError");

                    return View(new List<DesignImageViewModel>());
                }
            }

            return View(model);
        }
    }
}
