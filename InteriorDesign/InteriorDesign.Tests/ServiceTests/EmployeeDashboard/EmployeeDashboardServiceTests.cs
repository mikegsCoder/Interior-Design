using InteriorDesign.Core.Services.Employee.DashboardService;
using InteriorDesign.Core.ViewModels.EmployeeViewModels.DashboardViewModels;

namespace InteriorDesign.Tests.ServiceTests.EmployeeDashboard
{
    public class EmployeeDashboardServiceTests
    {
        private readonly ConfiguredProduct product;

        private readonly Infrastructure.Data.Models.DataBaseModels.Order order;

        private readonly Infrastructure.Data.Models.DataBaseModels.Contact contact;

        private readonly ChatMessage message;

        public EmployeeDashboardServiceTests()
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

            contact = new Infrastructure.Data.Models.DataBaseModels.Contact()
            {
                Id = Guid.NewGuid().ToString(),
                From = "user@mail.com",
                Subject = "subject",
                Message = "message",
                IsAnswered = false,
                CreatedOn = DateTime.Now,
            };

            message = new ChatMessage()
            {
                Sender = "employee1@mail.com",
                Message = "Message",
                CreatedOn = DateTime.Now
            };
        }

        [Fact]
        public async Task GetDashboardInfoReturnsDashboardViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            
            await dbContext.AddAsync(product);
            await dbContext.AddAsync(order);
            await dbContext.AddAsync(contact);
            await dbContext.AddAsync(message);

            await dbContext.SaveChangesAsync();

            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            using var orderss = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            using var contacts = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Contact>(dbContext);
            using var chatMessages = new EfDeletableEntityRepository<ChatMessage>(dbContext);

            var expected = new EmployeeDashboardVeiwModel()
            {
                Created = true,
                ConfiguredProductsCount = 1,
                OrdersCount = 1,
                OrdersValue = 123,
                NewContactsCount = 1,
                MessagesCount = 1,
            };

            var service = new EmployeeDashboardService(
                configuredProducts,
                orderss,
                contacts,
                chatMessages);

            var actual = await service.GetDashboardInfo();

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetDashboardInfoReturnsEmptyDashboardViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            using var orderss = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Order>(dbContext);
            using var contacts = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Contact>(dbContext);
            using var chatMessages = new EfDeletableEntityRepository<ChatMessage>(dbContext);

            var expected = new EmployeeDashboardVeiwModel()
            {
                Created = true,
                ConfiguredProductsCount = 0,
                OrdersCount = 0,
                OrdersValue = 0,
                NewContactsCount = 0,
                MessagesCount = 0,
            };

            var service = new EmployeeDashboardService(
                configuredProducts,
                orderss,
                contacts,
                chatMessages);

            var actual = await service.GetDashboardInfo();

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
