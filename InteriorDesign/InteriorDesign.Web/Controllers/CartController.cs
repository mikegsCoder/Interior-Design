using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InteriorDesign.Core.Services.Application.CartService;
using InteriorDesign.Core.ViewModels.ConfiguredProductViewModels;
using InteriorDesign.Web.Extensions;

namespace InteriorDesign.Web.Controllers
{
    [Authorize]
    public class CartController : BaseController
    {
        private readonly ICartService _service;
        private readonly ILogger _logger;

        public CartController(
            ICartService service,
            ILogger<CartController> logger)
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

                var products = await _service.GetAllProductsByUserIdAsync(User.Id());

                return View(products);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(CartController), nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(string productId)
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
                return RedirectToError(ex, _logger, nameof(CartController), nameof(EditProduct));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ConfiguredProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                await _service.EditAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(CartController), nameof(EditProduct));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string productId)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                await _service.DeleteProductByIdAsync(productId);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(CartController), nameof(Delete));
            }
        }
    }
}
