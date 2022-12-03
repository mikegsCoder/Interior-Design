using InteriorDesign.Core.ViewModels.OrderViewModels;

namespace InteriorDesign.Core.Services.Common.OrderService
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> GetNotShippedOrdersAsync();

        Task<OrderViewModel> GetOrderInfoByOrderIdAsync(string orderId);

        Task ShipOrderAsync(string orderId);
    }
}
