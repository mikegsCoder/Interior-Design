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
    }
}
