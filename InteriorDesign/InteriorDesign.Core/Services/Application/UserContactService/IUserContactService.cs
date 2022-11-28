using InteriorDesign.Core.ViewModels.ContactViewModels;

namespace InteriorDesign.Core.Services.Application.UserContactService
{
    public interface IUserContactService
    {
        Task SaveMessageAsync(ContactViewModel model);
    }
}
