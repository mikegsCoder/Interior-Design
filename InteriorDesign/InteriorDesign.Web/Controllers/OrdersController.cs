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

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            model.UserId = User.Id();

            var price = String.Format("{0:0.00}", model.TotalPrice);
            var subject = "Your order confirmed";
            var body = $"<p>Email From: Interior Design</p><p>Dear {model.FirstName} {model.LastName},</p> <p>Thank you for your order.</p> <p>It will be shipped in 2 working days.</p> <p>Delivery address:</p> <p>{model.DeliveryAddress}</p> <p>Order total price: {price} Euro.</p> <p>Your order status: Confirmed.</p>";

            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                await _service.CreateOrderAsync(model);
                await _emailSender.SendAsync(subject, body, model.Email);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(OrdersController), nameof(CreateOrder));
            }
        }
    }
}
