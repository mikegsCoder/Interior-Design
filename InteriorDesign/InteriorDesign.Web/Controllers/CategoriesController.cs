using InteriorDesign.Core.Services.Application.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _service;
        private readonly ILogger _logger;

        public CategoriesController(
            ICategoryService service, 
            ILogger<CategoriesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var model = await _service.GetCategoriesInfoAsync();

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(Index));
            }
        }
    }
}
