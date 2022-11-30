using InteriorDesign.Core.Services.Application.CategoryService;
using InteriorDesign.Core.ViewModels.CategoryTypeViewModels;
using InteriorDesign.Core.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InteriorDesign.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _service;
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;

        public CategoriesController(
            ICategoryService service,
            ILogger<CategoriesController> logger,
            IMemoryCache cache)
        {
            _service = service;
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryViewModel>>("Categories", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetCategoriesInfoAsync();

                    _cache.Set("Categories", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(15)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(Index));
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Garden()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("Garden", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetTypesByCategoryInfoAsync("Garden");

                    _cache.Set("Garden", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(Garden));
                }
            }

            return View("CategoryType", model);
        }

        [HttpGet]
        public async Task<IActionResult> Kitchen()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("Kitchen", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetTypesByCategoryInfoAsync("Kitchen");

                    _cache.Set("Kitchen", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(Kitchen));
                }
            }

            return View("CategoryType", model);
        }

        [HttpGet]
        public async Task<IActionResult> Office()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("Office", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetTypesByCategoryInfoAsync("Office");

                    _cache.Set("Office", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(Office));
                }
            }

            return View("CategoryType", model);
        }

        [HttpGet]
        public async Task<IActionResult> BedRoom()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("BedRoom", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetTypesByCategoryInfoAsync("Bed Room");

                    _cache.Set("BedRoom", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(BedRoom));
                }
            }

            return View("CategoryType", model);
        }

        [HttpGet]
        public async Task<IActionResult> LivingRoom()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("LivingRoom", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetTypesByCategoryInfoAsync("Living Room");

                    _cache.Set("LivingRoom", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(LivingRoom));
                }
            }

            return View("CategoryType", model);
        }

        [HttpGet]
        public async Task<IActionResult> YoungRoom()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("YoungRoom", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetTypesByCategoryInfoAsync("Young Room");

                    _cache.Set("YoungRoom", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(CategoriesController), nameof(YoungRoom));
                }
            }

            return View("CategoryType", model);
        }
    }
}
