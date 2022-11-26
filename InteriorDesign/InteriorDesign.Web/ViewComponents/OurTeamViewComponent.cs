using InteriorDesign.Core.Services.Application.OurTeamService;
using InteriorDesign.Core.ViewModels.OurTeamViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.ViewComponents
{
    [ViewComponent(Name = "OurTeam")]
    public class OurTeamViewComponent : ViewComponent
    {
        private readonly IOurTeamService _ourTeamService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OurTeamViewComponent(
            IOurTeamService ourTeamService,
            IHttpContextAccessor httpContextAccessor)
        {
            _ourTeamService = ourTeamService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception();

                var model = _ourTeamService.GetTeamAsync().GetAwaiter().GetResult();

                return View(model);
            }
            catch (Exception)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Home/ApplicationError");

                return View(new List<OurTeamViewModel>());
            }
        }
    }
}
