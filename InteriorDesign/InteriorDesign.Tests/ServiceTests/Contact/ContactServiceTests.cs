using InteriorDesign.Core.Services.Common.ContactService;
using InteriorDesign.Core.ViewModels.AdministrationViewModels.ContactViewModels;

namespace InteriorDesign.Tests.ServiceTests.Contact
{
    public class ContactServiceTests
    {
        private readonly Infrastructure.Data.Models.DataBaseModels.Contact contact;

        public ContactServiceTests()
        {
            contact = new Infrastructure.Data.Models.DataBaseModels.Contact()
            {
                Id = Guid.NewGuid().ToString(),
                From = "user@mail.com",
                Subject = "subject",
                Message = "message",
                IsAnswered = false,
                CreatedOn = DateTime.Now,
            };
        }

        [Fact]
        public async Task ClearAnsweredAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var contacts = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Contact>(dbContext);

            contact.IsAnswered = true;

            await dbContext.AddAsync(contact);

            await dbContext.SaveChangesAsync();

            var service = new ContactService(contacts);

            await service.ClearAnsweredAsync();

            var actual = contacts.All();

            Assert.Empty(actual);
        }

        [Fact]
        public async Task GetAllContactsAsyncReturnsAdminContactViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var contacts = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Contact>(dbContext);

            await dbContext.AddAsync(contact);

            await dbContext.SaveChangesAsync();

            var expected = new List<AdminContactViewModel>();

            expected.Add(new AdminContactViewModel()
            {
                Id = contact.Id.ToString(),
                From = contact.From,
                Subject = contact.Subject,
                Message = contact.Message,
                Respond = String.Empty,
                IsAnswered = false
            });

            var service = new ContactService(contacts);

            var actual = await service.GetAllContactsAsync();

            Assert.Single(actual);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllContactsAsyncReturnsEmptyAdminContactViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var contacts = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Contact>(dbContext);

            var service = new ContactService(contacts);

            var actual = await service.GetAllContactsAsync();

            Assert.Empty(actual);
        }

        [Fact]
        public async Task GetContactByIdAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var contacts = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Contact>(dbContext);

            await dbContext.AddAsync(contact);

            await dbContext.SaveChangesAsync();

            var expected = new AdminContactViewModel()
            {
                Id = contact.Id.ToString(),
                From = contact.From,
                Subject = contact.Subject,
                Message = contact.Message,
                Respond = String.Empty,
                IsAnswered = false
            };

            var service = new ContactService(contacts);

            var actual = await service.GetContactByIdAsync(contact.Id.ToString());

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetContactByIdAsyncReturnsNull()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var contacts = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Contact>(dbContext);

            var service = new ContactService(contacts);

            var actual = await service.GetContactByIdAsync(contact.Id.ToString());

            Assert.Null(actual);
        }

        [Fact]
        public async Task GetNotAnsweredContactsAsyncReturnsListOfAdminContactViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var contacts = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Contact>(dbContext);

            await dbContext.AddAsync(contact);

            await dbContext.SaveChangesAsync();

            var expected = new List<AdminContactViewModel>();

            expected.Add(new AdminContactViewModel()
            {
                Id = contact.Id.ToString(),
                From = contact.From,
                Subject = contact.Subject,
                Message = contact.Message,
                Respond = String.Empty,
                IsAnswered = false
            });

            var service = new ContactService(contacts);

            var actual = await service.GetNotAnsweredContactsAsync();

            Assert.Single(actual);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetNotAnsweredContactsAsyncReturnsEmptyListOfAdminContactViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var contacts = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Contact>(dbContext);

            contact.IsAnswered = true;

            await dbContext.AddAsync(contact);

            await dbContext.SaveChangesAsync();

            var service = new ContactService(contacts);

            var actual = await service.GetNotAnsweredContactsAsync();

            Assert.Empty(actual);
        }

        [Fact]
        public async Task MarkContactAsAnsweredAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var contacts = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Contact>(dbContext);

            await dbContext.AddAsync(contact);

            await dbContext.SaveChangesAsync();

            var service = new ContactService(contacts);

            await service.MarkContactAsAnsweredAsync(contact.Id.ToString());

            var actual = contacts.All();

            Assert.Single(actual);
            Assert.True(actual.First().IsAnswered);
        }

        [Fact]
        public async Task MarkContactAsAnsweredAsyncThrowsException()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var contacts = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Contact>(dbContext);

            var service = new ContactService(contacts);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.MarkContactAsAnsweredAsync("test"));
        }
    }
}
