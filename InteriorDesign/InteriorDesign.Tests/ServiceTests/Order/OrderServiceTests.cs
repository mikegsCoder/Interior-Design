using InteriorDesign.Core.ViewModels.OrderViewModels;
using InteriorDesign.Core.Services.Common.OrderService;

namespace InteriorDesign.Tests.ServiceTests.Order
{
    public class OrderServiceTests
    {
        private readonly Infrastructure.Data.Models.DataBaseModels.Order order;

        public OrderServiceTests()
        {
            order = new Infrastructure.Data.Models.DataBaseModels.Order()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "firstName",
                LastName = "lastName",
                Email = "email.mail.com",
                Phone = "359123456789",
                DeliveryAddress = "deliveryAddress",
                AdditionalDetails = "additionalDetails",
                Price = 123,
                ApplicationUserId = Guid.NewGuid().ToString()
            };
        }

        [Fact]
        public async Task ClearShippedAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var orders = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            order.IsShipped = true;

            await dbContext.AddAsync(order);

            await dbContext.SaveChangesAsync();

            var service = new OrderService(
                orders,
                configuredProducts.Object);

            Assert.Single(orders.All());

            await service.ClearShippedAsync();

            Assert.Empty(orders.All());
        }

        [Fact]
        public async Task GetNotShippedOrdersAsyncReturnsListOfOrderViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var orders = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            await dbContext.AddAsync(order);

            await dbContext.SaveChangesAsync();

            var expected = new List<OrderViewModel>();

            expected.Add(new OrderViewModel()
            {
                OrderId = order.Id.ToString(),
                FirstName = order.FirstName,
                LastName = order.LastName,
                Email = order.Email,
                Phone = order.Phone,
                DeliveryAddress = order.DeliveryAddress,
                AdditionalDetails = order.AdditionalDetails,
                Price = order.Price,
                IsShipped = order.IsShipped,
                ShippedOn = order.ShippedOn
            });

            var service = new OrderService(
                orders,
                configuredProducts.Object);

            var actual = await service.GetNotShippedOrdersAsync();

            Assert.Single(actual);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetNotShippedOrdersAsyncReturnsEmptyListOfOrderViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var orders = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            order.IsShipped = true;

            await dbContext.AddAsync(order);

            await dbContext.SaveChangesAsync();

            var service = new OrderService(
                orders,
                configuredProducts.Object);

            var actual = await service.GetNotShippedOrdersAsync();

            Assert.Empty(actual);
        }

        [Fact]
        public async Task GetOrderInfoByOrderIdAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var orders = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            await dbContext.AddAsync(order);

            await dbContext.SaveChangesAsync();

            var expected = new OrderViewModel()
            {
                OrderId = order.Id.ToString(),
                FirstName = order.FirstName,
                LastName = order.LastName,
                Email = order.Email,
                Phone = order.Phone,
                DeliveryAddress = order.DeliveryAddress,
                AdditionalDetails = order.AdditionalDetails,
                Price = order.Price,
                IsShipped = order.IsShipped,
                ShippedOn = order.ShippedOn
            };

            var service = new OrderService(
                orders,
                configuredProducts.Object);

            var actual = await service.GetOrderInfoByOrderIdAsync(order.Id.ToString());

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetOrderInfoByOrderIdAsyncThrowsError()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var orders = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            var service = new OrderService(
                orders,
                configuredProducts.Object);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.GetOrderInfoByOrderIdAsync("test"));
        }

        [Fact]
        public async Task GetOrdersInfoAsyncReturnsListOfOrderViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var orders = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            await dbContext.AddAsync(order);

            await dbContext.SaveChangesAsync();

            var expected = new List<OrderViewModel>();

            expected.Add(new OrderViewModel()
            {
                OrderId = order.Id.ToString(),
                FirstName = order.FirstName,
                LastName = order.LastName,
                Email = order.Email,
                Phone = order.Phone,
                DeliveryAddress = order.DeliveryAddress,
                AdditionalDetails = order.AdditionalDetails,
                Price = order.Price,
                IsShipped = order.IsShipped,
                ShippedOn = order.ShippedOn
            });

            var service = new OrderService(
                orders,
                configuredProducts.Object);

            var actual = await service.GetOrdersInfoAsync();

            Assert.Single(actual);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetOrdersInfoAsyncReturnsEmptyListOfOrderViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var orders = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            var service = new OrderService(
                orders,
                configuredProducts.Object);

            var actual = await service.GetOrdersInfoAsync();

            Assert.Empty(actual);
        }

        [Fact]
        public async Task ShipOrderAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var orders = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);

            await dbContext.AddAsync(order);

            await dbContext.SaveChangesAsync();

            var service = new OrderService(
                orders,
                configuredProducts);

            await service.ShipOrderAsync(order.Id.ToString());

            var allOrders = orders.All();

            Assert.Single(allOrders);
            Assert.True(allOrders.First().IsShipped);
        }

        [Fact]
        public async Task ShipOrderAsyncThrowsError()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var orders = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);

            var service = new OrderService(
                orders,
                configuredProducts);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.ShipOrderAsync("test"));
        }
    }
}
