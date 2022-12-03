using InteriorDesign.Core.Constants;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Core.ViewModels.ChatViewModels
{
    public class ChatViewModel
    {
        public string Sender { get; set; } = String.Empty;

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.ChatMessageMaxLength,
            MinimumLength = ViewModelsConstants.ChatMessageMinLength, 
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string Message { get; set; } = String.Empty;

        public ICollection<ChatMessage> Messages { get; set; } = null!;
    }
}
