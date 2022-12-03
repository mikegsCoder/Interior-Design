using InteriorDesign.Core.Services.Common.EmailSendService;
using InteriorDesign.Core.Services.Common.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Areas.Employee.Controllers
{
    public class OrdersController : BaseEmployeeController
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

        public async Task<IActionResult> NewOrders()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception");

                var model = await _service.GetNotShippedOrdersAsync();

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(OrdersController), nameof(NewOrders));
            }
        }
    }
}
