using InteriorDesign.Core.Services.Application.TypeService;
using InteriorDesign.Core.ViewModels.CategoryTypeViewModels;
using InteriorDesign.Core.ViewModels.TypeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InteriorDesign.Web.Controllers
{
    public class TypesController : BaseController
    {
        private readonly ITypeService _service;
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;

        public TypesController(
            ITypeService service,
            ILogger<TypesController> logger,
            IMemoryCache cache)
        {
            _service = service;
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!_cache.TryGetValue<IEnumerable<TypeViewModel>>("AllTypes", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetTypesInfoAsync();

                    _cache.Set("AllTypes", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(15)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(TypesController), nameof(Index));
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Wardrobe()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("Wardrobe", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetCategoriesByTypeInfoAsync("Wardrobe");

                    _cache.Set("Wardrobe", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(TypesController), nameof(Wardrobe));
                }
            }

            return View("TypeCategory", model);
        }

        [HttpGet]
        public async Task<IActionResult> Desk()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("Desk", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetCategoriesByTypeInfoAsync("Desk");

                    _cache.Set("Desk", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(TypesController), nameof(Desk));
                }
            }

            return View("TypeCategory", model);
        }

        [HttpGet]
        public async Task<IActionResult> Chair()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("Chair", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetCategoriesByTypeInfoAsync("Chair");

                    _cache.Set("Chair", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(TypesController), nameof(Chair));
                }
            }

            return View("TypeCategory", model);
        }

        [HttpGet]
        public async Task<IActionResult> Bed()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("Bed", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetCategoriesByTypeInfoAsync("Bed");

                    _cache.Set("Bed", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(TypesController), nameof(Bed));
                }
            }

            return View("TypeCategory", model);
        }

        [HttpGet]
        public async Task<IActionResult> Table()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("Table", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetCategoriesByTypeInfoAsync("Table");

                    _cache.Set("Table", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(TypesController), nameof(Table));
                }
            }

            return View("TypeCategory", model);
        }

        [HttpGet]
        public async Task<IActionResult> Sofa()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("Sofa", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetCategoriesByTypeInfoAsync("Sofa");

                    _cache.Set("Sofa", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(TypesController), nameof(Sofa));
                }
            }

            return View("TypeCategory", model);
        }

        [HttpGet]
        public async Task<IActionResult> Cabinet()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("Cabinet", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetCategoriesByTypeInfoAsync("Cabinet");

                    _cache.Set("Cabinet", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(TypesController), nameof(Cabinet));
                }
            }

            return View("TypeCategory", model);
        }

        [HttpGet]
        public async Task<IActionResult> Shelf()
        {
            if (!_cache.TryGetValue<IEnumerable<CategoryTypeViewModel>>("Shelf", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetCategoriesByTypeInfoAsync("Shelf");

                    _cache.Set("Shelf", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(TypesController), nameof(Shelf));
                }
            }

            return View("TypeCategory", model);
        }
    }
}
