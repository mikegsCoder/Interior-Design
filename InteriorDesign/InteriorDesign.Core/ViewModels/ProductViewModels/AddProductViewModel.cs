using InteriorDesign.Core.Constants;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Core.ViewModels.ProductViewModels
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.AddProductNameMaxLength,
            MinimumLength = ViewModelsConstants.AddProductNameMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        public string? ModelId { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        public string? ColorId { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [Range(
            ViewModelsConstants.AddProductPriceMinRange,
            ViewModelsConstants.AddProductPriceMaxRange, 
            ErrorMessage = ViewModelsConstants.PriceRangeErrorMessage)]
        public string? ProductPrice { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.AddProductImageUrlMaxLength,
            MinimumLength = ViewModelsConstants.AddProductImageUrlMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string? ImageUrl { get; set; }

        public IEnumerable<ProductColor> Colors { get; set; } = new List<ProductColor>();

        public IEnumerable<ProductModel> Models { get; set; } = new List<ProductModel>();
    }
}
