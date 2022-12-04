using InteriorDesign.Core.Services.Common.ContactService;
using InteriorDesign.Core.Services.Common.EmailSendService;
using InteriorDesign.Core.ViewModels.AdministrationViewModels.ContactViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    public class ContactsController : BaseAdminController
    {
        private readonly IContactService _contactService;
        private readonly IAppEmailSender _emailSender;
        private readonly ILogger _logger;

        public ContactsController(
            IContactService contactService,
            IAppEmailSender emailSender,
            ILogger<ContactsController> logger)
        {
            _contactService = contactService;
            _emailSender = emailSender;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception!");

                var model = await _contactService.GetAllContactsAsync();

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ContactsController), nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> AnswerToContact(string contactId)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception!");

                var contact = await _contactService.GetContactByIdAsync(contactId);

                return View(contact);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ContactsController), nameof(AnswerToContact));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AnswerToContact(AdminContactViewModel model)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception!");

                var subject = model.Subject;
                var body = $"<p>Email From: Interior Design</p><p>{model.Respond}</p> <p>Kind regards,</p> <p>  Interior Design Team.</p> <p>...</p> <p>{model.From} wrote:</p> <p>{model.Message}</p>";

                await _emailSender.SendAsync(subject, body, model.From);
                await _contactService.MarkContactAsAnsweredAsync(model.Id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ContactsController), nameof(AnswerToContact));
            }
        }

        public async Task<IActionResult> ClearAnswered()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception!");

                await _contactService.ClearAnsweredAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ContactsController), nameof(ClearAnswered));
            }
        }
    }
}
