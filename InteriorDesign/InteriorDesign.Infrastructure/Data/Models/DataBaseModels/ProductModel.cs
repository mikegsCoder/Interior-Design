using InteriorDesign.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteriorDesign.Infrastructure.Data.Models.DataBaseModels
{
    public class ProductModel : BaseDeletableModel<string>
    {
        public ProductModel()
        {
            Id = Guid.NewGuid().ToString();
            Products = new HashSet<Product>();
        }

        [Required]
        [StringLength(DataConstants.ProductModelNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public ProductType Type { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public ProductCategory Category { get; set; }

        [Required]
        public virtual ICollection<Product> Products { get; set; }
    }
}
