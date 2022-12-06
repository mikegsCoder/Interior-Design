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
    }
}
