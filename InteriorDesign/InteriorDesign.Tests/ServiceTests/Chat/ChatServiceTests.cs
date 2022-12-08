using InteriorDesign.Core.Services.Common.ChatService;
using InteriorDesign.Core.ViewModels.ChatViewModels;

namespace InteriorDesign.Tests.ServiceTests.Chat
{
    public class ChatServiceTests
    {
        private readonly ChatMessage message;

        public ChatServiceTests()
        {
            message = new ChatMessage()
            {
                Sender = "employee1@mail.com",
                Message = "Message",
                CreatedOn = DateTime.Now
            };
        }

        [Fact]
        public async Task ClearChatHistoryAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var messages = new EfDeletableEntityRepository<ChatMessage>(dbContext);

            await dbContext.AddAsync(message);

            await dbContext.SaveChangesAsync();

            var service = new ChatService(messages);

            await service.ClearChatHistoryAsync();

            var actual = messages.All();

            Assert.Empty(actual);
        }

        [Fact]
        public async Task GetAllMessagesAsyncReturnsChatViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var messages = new EfDeletableEntityRepository<ChatMessage>(dbContext);

            await dbContext.AddAsync(message);

            await dbContext.SaveChangesAsync();

            var expected = new ChatViewModel();

            expected.Messages = new List<ChatMessage>();

            expected.Messages.Add(message);

            var service = new ChatService(messages);

            var actual = await service.GetAllMessagesAsync();

            Assert.Single(actual.Messages);
            Assert.Equal(expected.Messages.Count, actual.Messages.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllMessagesAsyncReturnsEmptyChatViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var messages = new EfDeletableEntityRepository<ChatMessage>(dbContext);

            var expected = new ChatViewModel();

            expected.Messages = new List<ChatMessage>();

            var service = new ChatService(messages);

            var actual = await service.GetAllMessagesAsync();

            Assert.Empty(actual.Messages);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task SaveMessageAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var messages = new EfDeletableEntityRepository<ChatMessage>(dbContext);

            var model = new ChatViewModel()
            {
                Sender = "sender",
                Message = "message"
            };

            var service = new ChatService(messages);

            await service.SaveMessageAsync(model);

            var actual = messages.All();

            Assert.Single(actual);
            Assert.Equal(actual.First().Message, model.Message);
            Assert.Equal(actual.First().Sender, model.Sender);
        }
    }
}
