using InteriorDesign.Core.Services.Application.ProductService;
using InteriorDesign.Core.ViewModels.ProductViewModels;
using InteriorDesign.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace InteriorDesign.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _service;
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;

        public ProductsController(
            IProductService service,
            ILogger<ProductsController> logger,
            IMemoryCache cache)
        {
            _service = service;
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!_cache.TryGetValue<IEnumerable<ProductInfoViewModel>>("AllProducts", out var products))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    products = await _service.GetAllProductsAsync();

                    _cache.Set("AllProducts", products, TimeSpan.FromMinutes(5));
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ProductsController), nameof(Index));
                }
            }

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Products(string modelId)
        {
            if (!_cache.TryGetValue<IEnumerable<ProductInfoViewModel>>("ProductsByModel", out var products))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    products = await _service.GetProductsByModelIdAsync(modelId);

                    _cache.Set("ProductsByModel", products, TimeSpan.FromMinutes(5));
                }
                catch (Exception ex)
                {
                    return RedirectToError(ex, _logger, nameof(ProductsController), nameof(Products));
                }
            }

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Product(string productId)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var viewModel = await _service.GetProductByIdAsync(productId);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ProductsController), nameof(Product));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Product(ProductViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            model.UserId = User.Id();

            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                await _service.AddToCartAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ProductsController), nameof(Product));
            }
        }
    }
}
