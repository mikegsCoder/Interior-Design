using InteriorDesign.Core.ViewModels.ContactViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;

namespace InteriorDesign.Core.Services.Application.UserContactService
{
    public class UserContactService : IUserContactService
    {
        private readonly IDeletableEntityRepository<Contact> _contacts;

        public UserContactService(IDeletableEntityRepository<Contact> contacts)
        {
            _contacts = contacts;
        }

        public async Task SaveMessageAsync(ContactViewModel model)
        {
            var contact = new Contact()
            {
                From = model.From,
                Subject = model.Subject,
                Message = model.Message,
                CreatedOn = DateTime.UtcNow,
                IsAnswered = false,
                IsDeleted = false
            };

            await _contacts.AddAsync(contact);

            await _contacts.SaveChangesAsync();
        }
    }
}
