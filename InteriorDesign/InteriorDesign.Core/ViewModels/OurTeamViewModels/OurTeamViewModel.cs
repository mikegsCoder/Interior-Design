using InteriorDesign.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Core.ViewModels.OurTeamViewModels
{
    public class OurTeamViewModel
    {
        public string MemberId { get; set; } = null!;

        public string? Name { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.TeamMemberPositionMaxLength,
            MinimumLength = ViewModelsConstants.TeamMemberPositionMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string Position { get; set; } = null!;

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.TeamMemberImageUrlMaxLength,
            MinimumLength = ViewModelsConstants.TeamMemberImageUrlMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.TeamMemberSocialUrlMaxLength,
            MinimumLength = ViewModelsConstants.TeamMemberSocialUrlMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string TwitterUrl { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.TeamMemberSocialUrlMaxLength,
            MinimumLength = ViewModelsConstants.TeamMemberSocialUrlMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string FacebookUrl { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.TeamMemberSocialUrlMaxLength,
            MinimumLength = ViewModelsConstants.TeamMemberSocialUrlMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string GooglePlusUrl { get; set; }

        [Required(ErrorMessage = ViewModelsConstants.RequiredErrorMessage)]
        [StringLength(
            ViewModelsConstants.TeamMemberSocialUrlMaxLength,
            MinimumLength = ViewModelsConstants.TeamMemberSocialUrlMinLength,
            ErrorMessage = ViewModelsConstants.StringLenghtErrorMessage)]
        public string LinkedInUrl { get; set; }
    }
}
