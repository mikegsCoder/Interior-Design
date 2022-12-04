using InteriorDesign.Core.ViewModels.ChatViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Core.Services.Common.ChatService
{
    public class ChatService : IChatService
    {
        private readonly IDeletableEntityRepository<ChatMessage> _messages;

        public ChatService(IDeletableEntityRepository<ChatMessage> messages)
        {
            _messages = messages;
        }

        public async Task ClearChatHistoryAsync()
        {
            var chatMessages = await _messages.All()
                .ToListAsync();

            foreach (var message in chatMessages)
            {
                _messages.Delete(message);
            }

            await _messages.SaveChangesAsync();
        }

        public async Task<ChatViewModel> GetAllMessagesAsync()
        {
            var chatmodel = new ChatViewModel();

            chatmodel.Messages = await _messages.All()
                .OrderByDescending(m => m.CreatedOn)
                .ToListAsync();

            return chatmodel;
        }

        public async Task SaveMessageAsync(ChatViewModel model)
        {
            var messageContent = model.Message
                .Replace(":)", "🙂")
                .Replace(":(", "🙁")
                .Replace(";)", "😉")
                .Replace(":*", "😘")
                .Replace("<3", "❤")
                .Replace(":D", "😀")
                .Replace(":P", "😜");

            var message = new ChatMessage()
            {
                Sender = model.Sender,
                Message = messageContent,
                CreatedOn = DateTime.UtcNow
            };

            await _messages.AddAsync(message);
            await _messages.SaveChangesAsync();
        }
    }
}
