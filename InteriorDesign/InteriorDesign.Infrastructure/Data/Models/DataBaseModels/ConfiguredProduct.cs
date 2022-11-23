using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteriorDesign.Infrastructure.Data.Models.DataBaseModels
{
    public class ConfiguredProduct : BaseDeletableModel<string>
    {
        public ConfiguredProduct()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        [Required]
        [Range(1, 5)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public bool IsOrdered { get; set; }

        public DateTime? OrderedOn { get; set; }
    }
}
