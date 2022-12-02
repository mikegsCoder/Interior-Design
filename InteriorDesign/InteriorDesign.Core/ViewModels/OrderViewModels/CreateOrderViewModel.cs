using InteriorDesign.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Core.ViewModels.OrderViewModels
{
    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.CreateOrderFirstNameMaxLength, 
            MinimumLength = ViewModelsConstants.CreateOrderFirstNameMinLength, 
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.CreateOrderLastNameMaxLength,
            MinimumLength = ViewModelsConstants.CreateOrderLastNameMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string LastName { get; set; } = null!;

        public string? UserId { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.CreateOrderDeliveryAddressMaxLength,
            MinimumLength = ViewModelsConstants.CreateOrderDeliveryAddressMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string DeliveryAddress { get; set; } = null!;

        [MaxLength(
            ViewModelsConstants.CreateOrderDeliveryAddressMaxLength,
            ErrorMessage = ViewModelsConstants.MaxLendthErrorMessage)]
        public string? AdditionalDetails { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.CreateOrderPhoneMaxLength,
            MinimumLength = ViewModelsConstants.CreateOrderPhoneMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        [Phone(ErrorMessage = ViewModelsConstants.PhoneErrorMessage)]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.CreateOrderEmailMaxLength,
            MinimumLength = ViewModelsConstants.CreateOrderEmailMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        [EmailAddress(ErrorMessage = ViewModelsConstants.EmailErrorMessage)]
        public string Email { get; set; } = null!;

        public decimal TotalPrice { get; set; }
    }
}
