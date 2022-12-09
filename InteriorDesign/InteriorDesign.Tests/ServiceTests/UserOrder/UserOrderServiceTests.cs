using InteriorDesign.Core.Services.Application.UserOrderService;
using InteriorDesign.Core.ViewModels.OrderViewModels;

namespace InteriorDesign.Tests.ServiceTests.UserOrder
{
    public class UserOrderServiceTests
    {
        private readonly ConfiguredProduct product;

        public UserOrderServiceTests()
        {
            product = new ConfiguredProduct()
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = Guid.NewGuid().ToString(),
                Product = null,
                Quantity = 1,
                Price = 123,
                UserId = Guid.NewGuid().ToString(),
                IsDeleted = false,
                IsOrdered = false
            };
        }

        [Fact]
        public async Task CreateOrderAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var orders = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);

            await dbContext.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var model = new CreateOrderViewModel()
            {
                FirstName = "Ivan",
                LastName = "Popov",
                UserId = product.UserId,
                DeliveryAddress = "Devilery Address",
                AdditionalDetails = "Additional Details",
                Phone = "359123456789",
                Email = "email.mail.com",
                TotalPrice = 123
            };

            var service = new UserOrderService(
                orders,
                configuredProducts);

            await service.CreateOrderAsync(model);

            var actualOrders = orders.All();
            var actualProducts = configuredProducts.All();

            Assert.Single(actualOrders);
            Assert.True(actualOrders.First().ApplicationUserId == model.UserId);
            Assert.True(actualOrders.First().FirstName == model.FirstName);
            Assert.True(actualOrders.First().LastName == model.LastName);
            Assert.True(actualOrders.First().Email == model.Email);
            Assert.True(actualOrders.First().DeliveryAddress == model.DeliveryAddress);
            Assert.True(actualOrders.First().DeliveryAddress == model.DeliveryAddress);
            Assert.True(actualOrders.First().AdditionalDetails == model.AdditionalDetails);
            Assert.True(actualOrders.First().Price == model.TotalPrice);

            Assert.Single(actualProducts);
            Assert.True(actualProducts.First().IsOrdered);
        }

        [Fact]
        public async Task GetOrderInfoAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var orders = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);

            await dbContext.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var model = new CreateOrderViewModel()
            {
                FirstName = "Ivan",
                LastName = "Popov",
                UserId = product.UserId,
                DeliveryAddress = "Devilery Address",
                AdditionalDetails = "Additional Details",
                Phone = "359123456789",
                Email = "email.mail.com",
                TotalPrice = 123
            };

            var expected = new CreateOrderViewModel()
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
                Phone = string.Empty,
                DeliveryAddress = string.Empty,
                AdditionalDetails = string.Empty,
                TotalPrice = model.TotalPrice,
                UserId = null
            };

            var service = new UserOrderService(
                orders,
                configuredProducts);

            var actual = await service.GetOrderInfoAsync(model.UserId);

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
