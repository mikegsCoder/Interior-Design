using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.ViewComponents
{
    [ViewComponent(Name = "ContactInfo")]
    public class ContactInfoViewComponent : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public ContactInfoViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Address = _configuration["Contacts:Address"];
            ViewBag.Phone = _configuration["Contacts:Phone"];
            ViewBag.Email = _configuration["Contacts:Email"];

            return View();
        }
    }
}
