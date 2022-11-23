using InteriorDesign.Infrastructure.Constants;
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
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        [Required]
        [Range(
            DataConstants.ConfiguredProductQuantityMin, 
            DataConstants.ConfiguredProductQuantityMax)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Precision(
            DataConstants.ConfiguredProductPricePrecision, 
            DataConstants.ConfiguredProductPriceScale)]
        public decimal Price { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public bool IsOrdered { get; set; }

        public DateTime? OrderedOn { get; set; }
    }
}
