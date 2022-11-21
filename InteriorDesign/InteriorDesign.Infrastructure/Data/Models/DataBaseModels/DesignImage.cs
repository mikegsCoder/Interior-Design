using InteriorDesign.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Infrastructure.Data.Models.DataBaseModels
{
    public class DesignImage : BaseDeletableModel<string>
    {
        public DesignImage()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [Url]
        [MaxLength(DataConstants.ImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(DataConstants.ImageNameMaxLength)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
