using InteriorDesign.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Infrastructure.Data.Models.DataBaseModels
{
    public class Testimonial : BaseDeletableModel<string>
    {
        public Testimonial()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(DataConstants.TestimonialAuthorMaxLength)]
        public string Author { get; set; }

        [Required]
        [MaxLength(DataConstants.TestimonialTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DataConstants.TestimonialContentMaxLength)]
        public string Content { get; set; }

        public bool IsActive { get; set; }
    }
}
