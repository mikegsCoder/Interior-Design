using InteriorDesign.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Infrastructure.Data.Models.DataBaseModels
{
    public class TeamMember : BaseDeletableModel<string>
    {
        public TeamMember()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(DataConstants.TeamMemberFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataConstants.TeamMemberLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(DataConstants.TeamMemberPositionMaxLength)]
        public string Position { get; set; }

        [Required]
        [Url]
        [MaxLength(DataConstants.TeamMemberImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        [Url]
        [MaxLength(DataConstants.TeamMemberTwitterUrlMaxLength)]
        public string TwitterUrl { get; set; }

        [Required]
        [Url]
        [MaxLength(DataConstants.TeamMemberFacebookUrlMaxLength)]
        public string FacebookUrl { get; set; }

        [Required]
        [Url]
        [MaxLength(DataConstants.TeamMemberGooglePlusUrlMaxLength)]
        public string GooglePlusUrl { get; set; }

        [Required]
        [MaxLength(DataConstants.TeamMemberLinkedInUrlMaxLength)]
        public string LinkedInUrl { get; set; }
    }
}
