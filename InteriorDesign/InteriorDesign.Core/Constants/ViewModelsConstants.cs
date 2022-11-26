namespace InteriorDesign.Core.Constants
{
    internal static class ViewModelsConstants
    {
        // ErrorMessages
        public const string RequiredErrorMessage = "The field is required!";
        public const string StringLenghtErrorMessage = "The field {0} must be between {2} and {1} characters long.";
        public const string MaxLendthErrorMessage = "The field {0} must be at most {1} characters long.";
        public const string MinLendthErrorMessage = "The field {0} must not be less than {1} characters.";
        public const string RangeErrorMessage = "The {0} value must be in range between {1} and {2}.";
        public const string PriceRangeErrorMessage = "The price must be in range between {1} and {2}.";
        public const string EmailErrorMessage = "Invalid email address.";
        public const string PhoneErrorMessage = "Invalid phone number.";

        // TeamMemberViewModel
        public const int TeamMemberPositionMinLength = 3;
        public const int TeamMemberPositionMaxLength = 35;
        public const int TeamMemberImageUrlMinLength = 5;
        public const int TeamMemberImageUrlMaxLength = 200;
        public const int TeamMemberSocialUrlMinLength = 5;
        public const int TeamMemberSocialUrlMaxLength = 100;
    }
}
