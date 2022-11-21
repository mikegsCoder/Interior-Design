using InteriorDesign.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Infrastructure.Data.Models.DataBaseModels
{
    public class ProductCategory : BaseDeletableModel<string>
    {
        public ProductCategory()
        {
            Id = Guid.NewGuid().ToString();
            ProductTypes = new HashSet<ProductType>();
        }

        [Required]
        [StringLength(DataConstants.ProductCategoryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Url]
        [StringLength(DataConstants.ProductCategoryImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        public virtual ICollection<ProductType> ProductTypes { get; set; }
    }
}
