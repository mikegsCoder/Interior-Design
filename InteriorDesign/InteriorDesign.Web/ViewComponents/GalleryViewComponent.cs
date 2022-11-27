using InteriorDesign.Core.Services.Application.GalleryService;
using InteriorDesign.Core.ViewModels.DesignImageViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.ViewComponents
{
    [ViewComponent(Name = "Gallery")]
    public class DashboardViewComponent : ViewComponent
    {
        private readonly IGalleryService _galleryService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public DashboardViewComponent(
            IGalleryService galleryService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<DashboardViewComponent> logger)
        {
            _galleryService = galleryService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public IViewComponentResult Invoke()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var model = _galleryService.GetActiveImagesAsync().GetAwaiter().GetResult();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(DashboardViewComponent), ": ", ex.Message), ex);

                _httpContextAccessor?.HttpContext?.Response.Redirect("/Home/ApplicationError");

                return View(new List<DesignImageViewModel>());
            }
        }
    }
}
