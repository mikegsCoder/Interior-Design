namespace InteriorDesign.Core.ViewModels.AdministrationViewModels.AccountViewModels
{
    public class UsersViewModel
    {
        public string Id { get; init; } = null!;

        public string Email { get; init; } = null!;

        public bool IsAdmin { get; init; }

        public bool IsEmployee { get; set; }

        public bool IsEmailConfirmed { get; init; }
    }
}
