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

        public async Task<ChatViewModel> GetAllMessagesAsync()
        {
            var chatmodel = new ChatViewModel();

            chatmodel.Messages = await _messages.All()
                .OrderByDescending(m => m.CreatedOn)
                .ToListAsync();

            return chatmodel;
        }
    }
}
