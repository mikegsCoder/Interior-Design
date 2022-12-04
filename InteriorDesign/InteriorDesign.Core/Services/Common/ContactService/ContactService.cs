using InteriorDesign.Core.ViewModels.AdministrationViewModels.ContactViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Core.Services.Common.ContactService
{
    public class ContactService : IContactService
    {
        private readonly IDeletableEntityRepository<Contact> _contacts;

        public ContactService(IDeletableEntityRepository<Contact> contacts)
        {
            _contacts = contacts;
        }

        public async Task ClearAnsweredAsync()
        {
            var contactsToClear = await _contacts.All()
                .Where(c => c.IsAnswered)
                .ToListAsync();

            foreach (var contact in contactsToClear)
            {
                _contacts.Delete(contact);
            }

            await _contacts.SaveChangesAsync();
        }

        public async Task<IEnumerable<AdminContactViewModel>> GetAllContactsAsync()
        {
            var contacts = await _contacts.AllAsNoTracking()
                .Select(c => new AdminContactViewModel()
                {
                    Id = c.Id,
                    From = c.From,
                    Subject = c.Subject,
                    Message = c.Message,
                    IsAnswered = c.IsAnswered
                })
                .ToListAsync();

            contacts = contacts
                .OrderBy(c => c.IsAnswered)
                .ToList();

            return contacts;
        }

        public async Task<AdminContactViewModel> GetContactByIdAsync(string contactId)
        {
            var contact = await _contacts.AllAsNoTracking()
                .Where(c => c.Id == contactId)
                .Select(c => new AdminContactViewModel()
                {
                    Id = c.Id,
                    From = c.From,
                    Subject = c.Subject,
                    Message = c.Message,
                })
                .FirstOrDefaultAsync();

            return contact;
        }

        public async Task<IEnumerable<AdminContactViewModel>> GetNotAnsweredContactsAsync()
        {
            var contacts = await _contacts.AllAsNoTracking()
              .Where(c => !c.IsAnswered)
              .Select(c => new AdminContactViewModel()
              {
                  Id = c.Id,
                  From = c.From,
                  Subject = c.Subject,
                  Message = c.Message,
                  IsAnswered = c.IsAnswered
              })
              .ToListAsync();

            return contacts;
        }

        public async Task MarkContactAsAnsweredAsync(string contactId)
        {
            var contact = await _contacts.All()
                .Where(c => c.Id == contactId)
                .FirstOrDefaultAsync();

            contact.IsAnswered = true;
            contact.ModifiedOn = DateTime.UtcNow;

            _contacts.Update(contact);

            await _contacts.SaveChangesAsync();
        }
    }
}
