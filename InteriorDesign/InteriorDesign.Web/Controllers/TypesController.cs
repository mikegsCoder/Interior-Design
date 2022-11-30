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
    }
}
