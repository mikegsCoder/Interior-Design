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
    }
}
