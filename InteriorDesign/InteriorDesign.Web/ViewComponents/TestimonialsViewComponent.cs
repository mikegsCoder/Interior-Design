using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.ViewComponents
{
    [ViewComponent(Name = "Testimonials")]
    public class TestimonialsViewComponent : ViewComponent
    {

        private readonly IAboutUsService _aboutUsService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TestimonialsViewComponent(
            IAboutUsService aboutUsService,
            IHttpContextAccessor httpContextAccessor)
        {
            _aboutUsService = aboutUsService;
            _httpContextAccessor = httpContextAccessor;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        public IViewComponentResult Invoke()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception();

                var model = _aboutUsService.GetActiveTestimonialsAsync().GetAwaiter().GetResult();

                return View(model);
            }
            catch (Exception)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Home/ApplicationError");

                return View(new List<TestimonialViewModel>());

                //return RedirectToAction("ApplicationError", "Home");
            }
        }
    }
}
