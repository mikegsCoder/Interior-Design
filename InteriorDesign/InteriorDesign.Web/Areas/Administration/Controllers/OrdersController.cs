using InteriorDesign.Core.Services.Common.OrderService;
using InteriorDesign.Core.Services.Common.EmailSendService;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    public class OrdersController : BaseAdminController
    {
        private readonly IOrderService _service;
        private readonly IAppEmailSender _emailSender;
        private readonly ILogger _logger;

        public OrdersController(
            IOrderService service, 
            IAppEmailSender emailSender,
            ILogger<OrdersController> logger)
        {
            _service = service;
            _emailSender = emailSender;
            _logger = logger;
        }

        public async Task<IActionResult> AllOrders()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception");

                var model = await _service.GetOrdersInfoAsync();

                return this.View(model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(OrdersController), nameof(AllOrders));
            }
        }

        [HttpGet]
        public async Task<IActionResult> ShipOrder(string orderId)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception");

                var model = await _service.GetOrderInfoByOrderIdAsync(orderId);

                var price = String.Format("{0:0.00}", model.Price);
                var subject = "Your order is shipped";
                var body = $"<p>Email From: Interior Design</p><p>Dear {model.FirstName} {model.LastName},</p> <p>We confirm new status of your order.</p> <p>Delivery address:</p> <p>{model.DeliveryAddress}</p> <p>Order total price: {price} Euro.</p> <p>Your order status: Shipped.</p>";

                await _service.ShipOrderAsync(orderId);
                await _emailSender.SendAsync(subject, body, model.Email);

                return RedirectToAction(nameof(AllOrders));
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(OrdersController), nameof(ShipOrder));
            }
        }

        [HttpGet]
        public async Task<IActionResult> ClearShipped()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception");

                await _service.ClearShippedAsync();

                return RedirectToAction(nameof(AllOrders));
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(OrdersController), nameof(ClearShipped));
            }
        }
    }
}
