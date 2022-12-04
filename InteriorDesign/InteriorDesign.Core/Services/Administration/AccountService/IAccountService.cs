using InteriorDesign.Core.ViewModels.AdministrationViewModels.AccountViewModels;

namespace InteriorDesign.Core.Services.Administration.AccountService
{
    public interface IAccountService
    {
        Task<IndexUsersViewModel> GetAccountsInfoAsync();

        Task<bool> MakeUserEmployeeAsync(string id);

        Task<bool> MakeUserAdministratorAsync(string id);
    }
}
