using InteriorDesign.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Infrastructure.Data.Models.DataBaseModels
{
    public class Contact : BaseDeletableModel<string>
    {
        public Contact()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(DataConstants.ContactFromMaxLength)]
        public string From { get; set; }

        [Required]
        [MaxLength(DataConstants.ContactSubjectMaxLength)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(DataConstants.ContsctMessageMaxLength)]
        public string Message { get; set; }

        public bool IsAnswered { get; set; }
    }
}
