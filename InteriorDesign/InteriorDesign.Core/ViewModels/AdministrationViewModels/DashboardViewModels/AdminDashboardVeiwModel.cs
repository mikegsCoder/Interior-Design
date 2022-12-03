namespace InteriorDesign.Core.ViewModels.AdministrationViewModels.DashboardViewModels
{
    public class AdminDashboardVeiwModel
    {
        public bool Created { get; set; }

        public int AccountsCount { get; init; }

        public int AdministratorsCount { get; init; }

        public int EmployeesCount { get; set; }

        public int CategoriesCount { get; init; }

        public int ModelsCount { get; init; }

        public int ColorsCount { get; init; }

        public int ProductsCount { get; init; }

        public int ConfiguredProductsCount { get; set; }

        public int OrdersCount { get; set; }

        public decimal OrdersValue { get; set; }

        public int TeamMembersCount { get; set; }

        public int ActiveGalleryImagesCount { get; set; }

        public int NewContactsCount { get; set; }

        public int MessagesCount { get; set; }

        public int TestimonialsCount { get; set; }
    }
}
