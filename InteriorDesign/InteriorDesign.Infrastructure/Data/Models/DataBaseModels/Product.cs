using InteriorDesign.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteriorDesign.Infrastructure.Data.Models.DataBaseModels
{
    public class Product : BaseDeletableModel<string>
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(DataConstants.ProductNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public ProductModel Model { get; set; }

        [Required]
        public string ColorId { get; set; }

        [ForeignKey(nameof(ColorId))]
        public ProductColor Color { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Range(DataConstants.ProductPriceMinRange, DataConstants.ProductPriceMaxRange)]
        [Precision(DataConstants.ProductPricePrecision, DataConstants.ProductPriceScale)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(DataConstants.ProductImageUrlMaxLength)]
        public string ImageUrl { get; set; }
    }
}
