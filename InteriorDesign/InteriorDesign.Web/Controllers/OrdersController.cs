using InteriorDesign.Core.Services.Common.EmailSendService;
using InteriorDesign.Core.Services.Application.UserOrderService;
using InteriorDesign.Core.ViewModels.OrderViewModels;
using InteriorDesign.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IUserOrderService _service;
        private readonly IAppEmailSender _emailSender;
        private readonly ILogger _logger;

        public OrdersController(
            IUserOrderService service, 
            IAppEmailSender emailSender,
            ILogger<OrdersController> logger)
        {
            _service = service;
            _emailSender = emailSender;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var model = await _service.GetOrderInfoAsync(User.Id());

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(OrdersController), nameof(Index));
            }
        }
    }
}
