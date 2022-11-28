namespace InteriorDesign.Core.ViewModels.ContactViewModels
{
    using InteriorDesign.Core.Constants;
    using System.ComponentModel.DataAnnotations;

    public class ContactViewModel
    {

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [EmailAddress(ErrorMessage = ViewModelsConstants.EmailErrorMessage)]
        [StringLength(
            ViewModelsConstants.ContactFromMaxLength,
            MinimumLength = ViewModelsConstants.ContactFromMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string From { get; set; } = null!;


        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.ContactFromMaxLength,
            MinimumLength = ViewModelsConstants.ContactFromMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string Subject { get; set; } = null!;

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.ContactMessageMaxLength,
            MinimumLength = ViewModelsConstants.ContactMessageMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string Message { get; set; } = null!;
    }
}
