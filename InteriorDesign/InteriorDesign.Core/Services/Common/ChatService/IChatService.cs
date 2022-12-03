using InteriorDesign.Core.ViewModels.ChatViewModels;

namespace InteriorDesign.Core.Services.Common.ChatService
{
    public interface IChatService
    {
        Task<ChatViewModel> GetAllMessagesAsync();
    }
}
