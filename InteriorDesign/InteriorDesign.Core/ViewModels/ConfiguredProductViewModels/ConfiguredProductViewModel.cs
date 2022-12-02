using InteriorDesign.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Core.ViewModels.ConfiguredProductViewModels
{
    public class ConfiguredProductViewModel
    {
        public string Id { get; set; } = null!;

        public string ProductId { get; set; } = null!;

        public string? CategoryName { get; set; }

        public string? TypeName { get; set; }

        public string? ProductName { get; set; }

        public string? ModelName { get; set; }

        public string? ColorName { get; set; }

        public decimal? ProductPrice { get; set; }

        public decimal? SinglePrice { get; set; }

        public string? ImageUrl { get; set; }

        public string? UserId { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [Range(
            ViewModelsConstants.ConfiguredProductQuantityMinRange,
            ViewModelsConstants.ConfiguredProductQuantityMaxRange,
            ErrorMessage = ViewModelsConstants.RangeErrorMessage)]
        public int Quantity { get; set; }
    }
}
