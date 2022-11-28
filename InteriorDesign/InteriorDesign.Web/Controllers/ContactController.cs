using InteriorDesign.Core.Services.Application.UserContactService;
using InteriorDesign.Core.ViewModels.ContactViewModels;
using InteriorDesign.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IUserContactService _contactService;
        private readonly ILogger _logger;

        public ContactController(
            IUserContactService contactService, 
            ILogger<ContactController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(string sent)
        {
            ViewBag.Message = sent;

            return View();
        }
    }
}
