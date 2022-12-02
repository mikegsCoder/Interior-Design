using InteriorDesign.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Core.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        public string ProductId { get; set; } = null!;

        public string? CategoryName { get; set; }

        public string? TypeName { get; set; }

        public string? ProductName { get; set; }

        public string? ModelName { get; set; }

        public string? ColorName { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [Range(
            ViewModelsConstants.ProductPriceMinRange,
            ViewModelsConstants.ProductPriceMaxRange,
            ErrorMessage = ViewModelsConstants.PriceRangeErrorMessage)]
        public string? ProductPriceString { get; set; }

        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.ProductImageUrlMaxLength,
            MinimumLength = ViewModelsConstants.ProductImageUrlMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string ImageUrl { get; set; } = null!;

        public string? UserId { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [Range(
            ViewModelsConstants.ProductQuantityMinRange,
            ViewModelsConstants.ProductQuantityMaxRange,
            ErrorMessage = ViewModelsConstants.RangeErrorMessage)]
        public int Quantity { get; set; }
    }
}
