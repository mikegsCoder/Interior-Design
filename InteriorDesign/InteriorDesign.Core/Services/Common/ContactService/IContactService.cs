using InteriorDesign.Core.ViewModels.AdministrationViewModels.ContactViewModels;

namespace InteriorDesign.Core.Services.Common.ContactService
{
    public interface IContactService
    {
        Task<IEnumerable<AdminContactViewModel>> GetNotAnsweredContactsAsync();
    }
}
