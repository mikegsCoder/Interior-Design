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

        public async Task<IEnumerable<OrderViewModel>> GetOrdersInfoAsync()
        {
            var ordersList = new List<OrderViewModel>();

            var orders = await _orders.AllAsNoTracking()
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

            ordersList = ordersList
                .OrderBy(o => o.IsShipped)
                .ThenBy(o => o.ShippedOn)
                .ToList();

            return ordersList;
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

        public async Task<OrderViewModel> GetOrderInfoByOrderIdAsync(string orderId)
        {
            var order = await _orders.AllAsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == orderId);

            var model = new OrderViewModel
            {
                OrderId = orderId,
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

            return model;
        }

        public async Task ShipOrderAsync(string orderId)
        {
            var order = await _orders.All()
                .Where(o => o.Id == orderId)
                .Include(o => o.ConfiguredProducts)
                .FirstOrDefaultAsync();

            order.IsShipped = true;
            order.ShippedOn = DateTime.UtcNow;
            order.ModifiedOn = DateTime.UtcNow;

            foreach (var configuredProduct in order.ConfiguredProducts)
            {
                _configuredProducts.Delete(configuredProduct);
            }

            _orders.Update(order);

            await _configuredProducts.SaveChangesAsync();
            await _orders.SaveChangesAsync();
        }
    }
}
