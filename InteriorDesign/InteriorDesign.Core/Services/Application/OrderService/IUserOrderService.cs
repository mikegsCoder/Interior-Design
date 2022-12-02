using InteriorDesign.Core.ViewModels.OrderViewModels;

namespace InteriorDesign.Core.Services.Application.UserOrderService
{
    public interface IUserOrderService
    {
        Task<CreateOrderViewModel> GetOrderInfoAsync(string userID);

        Task CreateOrderAsync(CreateOrderViewModel model);
    }
}
