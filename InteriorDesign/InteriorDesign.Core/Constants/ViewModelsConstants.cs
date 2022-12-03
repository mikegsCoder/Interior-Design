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

        // ContactViewModel
        public const int ContactFromMinLength = 8;
        public const int ContactFromMaxLength = 20;

        public const int ContactSubjectMinLength = 5;
        public const int ContactSubjectMaxLength = 50;

        public const int ContactMessageMinLength = 5;
        public const int ContactMessageMaxLength = 1000;

        // ProductViewModel
        public const double ProductPriceMinRange = 10.00;
        public const double ProductPriceMaxRange = 2000.00;

        public const int ProductImageUrlMinLength = 5;
        public const int ProductImageUrlMaxLength = 200;

        public const int ProductQuantityMinRange = 1;
        public const int ProductQuantityMaxRange = 9;

        // ConfiguredProductViewModel
        public const int ConfiguredProductQuantityMinRange = 1;
        public const int ConfiguredProductQuantityMaxRange = 9;

        // CreateOrderViewModel
        public const int CreateOrderFirstNameMinLength = 3;
        public const int CreateOrderFirstNameMaxLength = 20;

        public const int CreateOrderLastNameMinLength = 3;
        public const int CreateOrderLastNameMaxLength = 20;

        public const int CreateOrderDeliveryAddressMinLength = 5;
        public const int CreateOrderDeliveryAddressMaxLength = 200;

        public const int CreateOrderAdditionalDetailsMaxLength = 200;

        public const int CreateOrderPhoneMinLength = 7;
        public const int CreateOrderPhoneMaxLength = 15;

        public const int CreateOrderEmailMinLength = 5;
        public const int CreateOrderEmailMaxLength = 25;

        // ChatViewModel
        public const int ChatMessageMaxLength = 200;
        public const int ChatMessageMinLength = 2;
    }
}
