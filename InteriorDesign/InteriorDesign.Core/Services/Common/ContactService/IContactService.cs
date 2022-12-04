using InteriorDesign.Core.ViewModels.AdministrationViewModels.ContactViewModels;

namespace InteriorDesign.Core.Services.Common.ContactService
{
    public interface IContactService
    {
        Task<IEnumerable<AdminContactViewModel>> GetAllContactsAsync();

        Task<IEnumerable<AdminContactViewModel>> GetNotAnsweredContactsAsync();

        Task<AdminContactViewModel> GetContactByIdAsync(string contactId);

        Task MarkContactAsAnsweredAsync(string contactId);
    }
}
