using InteriorDesign.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Core.ViewModels.AdministrationViewModels.ContactViewModels
{
    public class AdminContactViewModel
    {
        public string Id { get; set; } = null!;

        public string From { get; set; } = null!;

        public string Subject { get; set; } = null!;

        public string Message { get; set; } = null!;

        [Required]
        [StringLength(
            ViewModelsConstants.RespondMaxLength, 
            MinimumLength = ViewModelsConstants.RespondMinLength, 
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string Respond { get; set; } = String.Empty;

        public bool IsAnswered { get; set; }
    }
}
