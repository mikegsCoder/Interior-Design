using InteriorDesign.Core.Services.Application.CartService;
using InteriorDesign.Core.Services.Application.ProductService;
using InteriorDesign.Core.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    public class ProductsController : BaseAdminController
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly ILogger _logger;

        public ProductsController(
            IProductService productService,
            ICartService cartService,
            ILogger<ProductsController> logger)
        {
            _productService = productService;
            _cartService = cartService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception");

                var products = await _productService.GetAllProductsAsync();

                return View(products);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ProductsController), nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Product(string productId)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception");

                if (await _cartService.ProductExistsInCartAsync(productId))
                {
                    TempData["Error"] = "Forbidden!";

                    return RedirectToAction(nameof(Index), new { Message = "Error" });
                }

                var viewModel = await _productService.GetProductByIdAsync(productId);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ProductsController), nameof(Product));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string productId)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception");

                var viewModel = await _productService.GetProductByIdAsync(productId);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ProductsController), nameof(Edit));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception");

                await _productService.EditProductAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ProductsController), nameof(Edit));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string productId)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception");

                await _productService.DeleteProductByIdAsync(productId);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ProductsController), nameof(Delete));
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception");

                var model = await _productService.GetAddProductViewModelAsync();

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ProductsController), nameof(AddProduct));
            }
        }
    }
}
