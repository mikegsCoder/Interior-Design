namespace InteriorDesign.Infrastructure.Constants
{
    internal static class DataConstants
    {
        // ChatMessage model
        public const int ChatSenderMaxLength = 30;
        public const int ChatMessageMaxLength = 200;

        // Contact model
        public const int ContactFromMaxLength = 20;
        public const int ContactSubjectMaxLength = 50;
        public const int ContsctMessageMaxLength = 1000;

        // DesignImage model
        public const int ImageUrlMaxLength = 100;
        public const int ImageNameMaxLength = 40;

        // Order model
        public const int OrderFirstNameMaxLength = 20;
        public const int OrderLastNameMaxLength = 20;
        public const int OrderDeliveryAddressMaxLength = 200;
        public const int OrderAdditionalDetailsMaxLength = 200;
        public const int OrderPricePrecision = 18;
        public const int OrderPriceScale = 2;

        // Product model
        public const int ProductNameMaxLength = 20;
        public const int ProductPriceMinRange = 10;
        public const int ProductPriceMaxRange = 2000;
        public const int ProductPricePrecision = 18;
        public const int ProductPriceScale = 2;
        public const int ProductImageUrlMaxLength = 200;

        // ProductCategory model
        public const int ProductCategoryNameMaxLength = 20;
        public const int ProductCategoryImageUrlMaxLength = 200;

        // ProductColor model
        public const int ProductColorNameMaxLength = 15;

        // ProductModel model
        public const int ProductModelNameMaxLength = 20;

        // ProductType model
        public const int ProductTypeNameMaxLength = 10;

        // TeamMemeber model
        public const int TeamMemberFirstNameMaxLength = 20;
        public const int TeamMemberLastNameMaxLength = 20;
        public const int TeamMemberPositionMaxLength = 35;
        public const int TeamMemberImageUrlMaxLength = 200;
        public const int TeamMemberTwitterUrlMaxLength = 100;
        public const int TeamMemberFacebookUrlMaxLength = 100;
        public const int TeamMemberGooglePlusUrlMaxLength = 100;
        public const int TeamMemberLinkedInUrlMaxLength = 100;

        // Testimonial model
        public const int TestimonialAuthorMaxLength = 30;
        public const int TestimonialTitleMaxLength = 30;
        public const int TestimonialContentMaxLength = 500;
    }
}
