using InteriorDesign.Core.ViewModels.OrderViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Core.Services.Common.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IDeletableEntityRepository<Order> _orders;
        private readonly IDeletableEntityRepository<ConfiguredProduct> _configuredProducts;

        public OrderService(
            IDeletableEntityRepository<Order> orders,
            IDeletableEntityRepository<ConfiguredProduct> configuredProducts)
        {
            _orders = orders;
            _configuredProducts = configuredProducts;
        }

        public async Task<IEnumerable<OrderViewModel>> GetNotShippedOrdersAsync()
        {
            var ordersList = new List<OrderViewModel>();

            var orders = await _orders.AllAsNoTracking()
                //.Where(o => !o.IsDeleted && !o.IsShipped)
                .Where(o => !o.IsShipped)
                .ToListAsync();

            foreach (var order in orders)
            {
                var model = new OrderViewModel
                {
                    OrderId = order.Id,
                    FirstName = order.FirstName,
                    LastName = order.LastName,
                    Email = order.Email,
                    Phone = order.Phone,
                    DeliveryAddress = order.DeliveryAddress,
                    AdditionalDetails = order.AdditionalDetails,
                    Price = order.Price,
                    IsShipped = order.IsShipped,
                    ShippedOn = order.ShippedOn,
                };

                ordersList.Add(model);
            }

            ordersList = ordersList.ToList();

            return ordersList;
        }
    }
}
