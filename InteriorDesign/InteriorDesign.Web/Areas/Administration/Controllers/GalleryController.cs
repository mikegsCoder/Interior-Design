using InteriorDesign.Core.Services.Application.GalleryService;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    public class GalleryController : BaseAdminController
    {
        private readonly IGalleryService _galleryService;
        private readonly ILogger _logger;

        public GalleryController(
            IGalleryService galleryService, 
            ILogger<GalleryController> logger)
        {
            _galleryService = galleryService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Deactivate(string imageId)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception!");

                await _galleryService.DeactivateImageAsync(imageId);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(GalleryController), nameof(Deactivate));
            }
        }
    }
}
