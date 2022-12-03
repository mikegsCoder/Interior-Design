using InteriorDesign.Core.Services.Common.ContactService;
using InteriorDesign.Core.Services.Common.EmailSendService;
using InteriorDesign.Core.ViewModels.AdministrationViewModels.ContactViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Areas.Employee.Controllers
{
    public class ContactsController : BaseEmployeeController
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
                //throw new Exception("Test exception");

                var model = await _contactService.GetNotAnsweredContactsAsync();

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ContactsController), nameof(Index));
            }
        }
    }
}
