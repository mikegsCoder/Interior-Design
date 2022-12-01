using InteriorDesign.Core.Services.Application.ModelService;
using InteriorDesign.Core.ViewModels.ProductModelViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InteriorDesign.Web.Controllers
{
    public class ModelsController : BaseController
    {
        private readonly IModelService _service;
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;

        public ModelsController(
            IModelService service,
            ILogger<ModelsController> logger,
            IMemoryCache cache)
        {
            _service = service;
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> BedRoom_Bed()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("BedRoom_Bed", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Bed Room", "Bed");

                    _cache.Set("BedRoom_Bed", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(BedRoom_Bed));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> BedRoom_Cabinet()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("BedRoom_Cabinet", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Bed Room", "Cabinet");

                    _cache.Set("BedRoom_Cabinet", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(BedRoom_Cabinet));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> BedRoom_Wardrobe()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("BedRoom_Wardrobe", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Bed Room", "Wardrobe");

                    _cache.Set("BedRoom_Wardrobe", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(BedRoom_Wardrobe));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> Garden_Chair()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("Garden_Chair", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Garden", "Chair");

                    _cache.Set("Garden_Chair", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(Garden_Chair));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> Garden_Table()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("Garden_Table", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Garden", "Table");

                    _cache.Set("Garden_Table", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(Garden_Table));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> Kitchen_Cabinet()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("Kitchen_Cabinet", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Kitchen", "Cabinet");

                    _cache.Set("Kitchen_Cabinet", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(Kitchen_Cabinet));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> Kitchen_Chair()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("Kitchen_Chair", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Kitchen", "Chair");

                    _cache.Set("Kitchen_Chair", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(Kitchen_Chair));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> Kitchen_Table()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("Kitchen_Table", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Kitchen", "Table");

                    _cache.Set("Kitchen_Table", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(Kitchen_Table));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> LivingRoom_Cabinet()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("LivingRoom_Cabinet", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Living Room", "Cabinet");

                    _cache.Set("LivingRoom_Cabinet", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(LivingRoom_Cabinet));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> LivingRoom_Chair()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("LivingRoom_Chair", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Living Room", "Chair");

                    _cache.Set("LivingRoom_Chair", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(LivingRoom_Chair));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> LivingRoom_Sofa()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("LivingRoom_Sofa", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Living Room", "Sofa");

                    _cache.Set("LivingRoom_Sofa", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(LivingRoom_Sofa));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> LivingRoom_Table()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("LivingRoom_Table", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Living Room", "Table");

                    _cache.Set("LivingRoom_Table", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(LivingRoom_Table));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> Office_Cabinet()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("Office_Cabinet", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Office", "Cabinet");

                    _cache.Set("Office_Cabinet", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(Office_Cabinet));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> Office_Chair()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("Office_Chair", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Office", "Chair");

                    _cache.Set("Office_Chair", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(Office_Chair));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> Office_Desk()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("Office_Desk", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Office", "Desk");

                    _cache.Set("Office_Desk", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(Office_Desk));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> Office_Shelf()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("Office_Shelf", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Office", "Shelf");

                    _cache.Set("Office_Shelf", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(Office_Shelf));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> Office_Wardrobe()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("Office_Wardrobe", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Office", "Wardrobe");

                    _cache.Set("Office_Wardrobe", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(Office_Wardrobe));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> YoungRoom_Bed()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("YoungRoom_Bed", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Young Room", "Bed");

                    _cache.Set("YoungRoom_Bed", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(YoungRoom_Bed));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> YoungRoom_Cabinet()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("YoungRoom_Cabinet", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Young Room", "Cabinet");

                    _cache.Set("YoungRoom_Cabinet", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(YoungRoom_Cabinet));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> YoungRoom_Chair()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("YoungRoom_Chair", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Young Room", "Chair");

                    _cache.Set("YoungRoom_Chair", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(YoungRoom_Chair));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> YoungRoom_Table()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("YoungRoom_Table", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Young Room", "Table");

                    _cache.Set("YoungRoom_Table", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(YoungRoom_Table));
                }
            }

            return View("CategoryTypeModels", model);
        }

        [HttpGet]
        public async Task<IActionResult> YoungRoom_Wardrobe()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductModelInfoViewModel>>("YoungRoom_Wardrobe", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = await _service.GetModelsInfoAsync("Young Room", "Wardrobe");

                    _cache.Set("YoungRoom_Wardrobe", model, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ModelsController), nameof(YoungRoom_Wardrobe));
                }
            }

            return View("CategoryTypeModels", model);
        }
    }
}
