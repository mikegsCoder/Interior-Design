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

        [HttpGet]
        public async Task<IActionResult> Garden()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var model = await _service.GetTypesByCategoryInfoAsync("Garden");

                return View("CategoryType", model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(Garden));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Kitchen()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var model = await _service.GetTypesByCategoryInfoAsync("Kitchen");

                return View("CategoryType", model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(Kitchen));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Office()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var model = await _service.GetTypesByCategoryInfoAsync("Office");

                return View("CategoryType", model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(Office));
            }
        }

        [HttpGet]
        public async Task<IActionResult> BedRoom()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var model = await _service.GetTypesByCategoryInfoAsync("Bed Room");

                return View("CategoryType", model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(BedRoom));
            }
        }

        [HttpGet]
        public async Task<IActionResult> LivingRoom()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var model = await _service.GetTypesByCategoryInfoAsync("Living Room");

                return View("CategoryType", model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(LivingRoom));
            }
        }

        [HttpGet]
        public async Task<IActionResult> YoungRoom()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var model = await _service.GetTypesByCategoryInfoAsync("Young Room");

                return View("CategoryType", model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(YoungRoom));
            }
        }
    }
}
