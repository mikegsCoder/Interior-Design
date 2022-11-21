using InteriorDesign.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Infrastructure.Data.Models.DataBaseModels
{
    public class ChatMessage : BaseDeletableModel<string>
    {
        public ChatMessage()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(DataConstants.ChatSenderMaxLength)]
        public string Sender { get; set; }

        [Required]
        [MaxLength(DataConstants.ChatMessageMaxLength)]
        public string Message { get; set; }
    }
}
