using InteriorDesign.Core.Constants;
using InteriorDesign.Core.Services.Application.GalleryService;
using InteriorDesign.Core.ViewModels.DesignImageViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Administration.ViewComponents
{
    [ViewComponent(Name = "AdminGallery")]
    public class AdminGalleryViewComponent : ViewComponent
    {
        private readonly IGalleryService _galleryService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public AdminGalleryViewComponent(
            IGalleryService galleryService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<AdminGalleryViewComponent> logger)
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

                var model = _galleryService.GetAllImagesAsync().GetAwaiter().GetResult();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(AdminGalleryViewComponent), ": ", ex.Message), ex);
                
                TempData["Error"] = ex.Message;

                _httpContextAccessor?.HttpContext?.Response.Redirect(WebConstants.AdminError);

                return View(new List<DesignImageViewModel>());
            }
        }
    }
}
