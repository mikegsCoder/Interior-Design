using InteriorDesign.Core.ViewModels.OrderViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Core.Services.Application.UserOrderService
{
    public class UserOrderService : IUserOrderService
    {   private readonly IDeletableEntityRepository<Order> _orders;
        private readonly IDeletableEntityRepository<ConfiguredProduct> _configuredProducts;

        public UserOrderService(
            IDeletableEntityRepository<Order> orders,
            IDeletableEntityRepository<ConfiguredProduct> configuredProducts)
        {
            _configuredProducts = configuredProducts;
            _orders = orders;
        }

        public async Task<CreateOrderViewModel> GetOrderInfoAsync(string userId)
        {
            var configuredProducts = await _configuredProducts.AllAsNoTracking()
                .Where(p => p.UserId == userId && !p.IsOrdered)
                .ToListAsync();

            var model = new CreateOrderViewModel
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
                Phone = string.Empty,
                DeliveryAddress = string.Empty,
                AdditionalDetails = string.Empty,
                TotalPrice = configuredProducts.Sum(x => x.Price),
            };
            
            return model;
        }

        public async Task CreateOrderAsync(CreateOrderViewModel model)
        {
            var configuredProducts = await _configuredProducts.All()
                .Where(p => p.UserId == model.UserId)
                .ToListAsync();

            var order = new Order
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                DeliveryAddress = model.DeliveryAddress,
                AdditionalDetails = model.AdditionalDetails,
                Price = model.TotalPrice,
                ApplicationUserId = model.UserId,
                IsShipped = false,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
                ConfiguredProducts = configuredProducts
            };

            foreach (var configuredProduct in configuredProducts)
            {
                configuredProduct.IsOrdered = true;
                configuredProduct.OrderedOn = DateTime.UtcNow;
            }

            await _orders.AddAsync(order);
            await _orders.SaveChangesAsync();
            await _configuredProducts.SaveChangesAsync();
        }
    }
}
