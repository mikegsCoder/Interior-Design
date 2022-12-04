namespace InteriorDesign.Core.ViewModels.AdministrationViewModels.AccountViewModels
{
    public class IndexUsersViewModel
    {
        public string? Message { get; set; }

        public bool Created { get; set; } = true;

        public List<UsersViewModel> Users { get; init; }
    }
}
