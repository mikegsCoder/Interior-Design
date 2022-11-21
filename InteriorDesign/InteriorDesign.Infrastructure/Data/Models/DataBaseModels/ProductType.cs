using InteriorDesign.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Infrastructure.Data.Models.DataBaseModels
{
    public class ProductType : BaseDeletableModel<string>
    {
        public ProductType()
        {
            Id = Guid.NewGuid().ToString();
            ProductCategories = new HashSet<ProductCategory>();
            ProductModels = new HashSet<ProductModel>();
        }

        [Required]
        [StringLength(DataConstants.ProductTypeNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        public virtual ICollection<ProductModel> ProductModels { get; set; }
    }
}
