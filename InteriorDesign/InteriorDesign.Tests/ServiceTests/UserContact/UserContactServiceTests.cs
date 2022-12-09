using InteriorDesign.Core.Services.Application.UserContactService;
using InteriorDesign.Core.ViewModels.ContactViewModels;

namespace InteriorDesign.Tests.ServiceTests.UserContact
{
    public class UserContactServiceTests
    {
        [Fact]
        public async Task SaveMessageAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var contacts = new EfDeletableEntityRepository<Infrastructure.Data.Models.DataBaseModels.Contact>(dbContext);
            
            var model = new ContactViewModel()
            {
                From = "test@mail.com",
                Subject = "test_subject",
                Message = "test_message"
            };

            var service = new UserContactService(contacts);

            await service.SaveMessageAsync(model);

            var actual = contacts.All();

            Assert.Single(actual);
            Assert.True(actual.First().From == model.From);
            Assert.True(actual.First().Subject == model.Subject);
            Assert.True(actual.First().Message == model.Message);
        }
    }
}
