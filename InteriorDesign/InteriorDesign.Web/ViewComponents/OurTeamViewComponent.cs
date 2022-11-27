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
        private readonly ILogger _logger;

        public OurTeamViewComponent(
            IOurTeamService ourTeamService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<OurTeamViewComponent> logger)
        {
            _ourTeamService = ourTeamService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public IViewComponentResult Invoke()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var model = _ourTeamService.GetTeamAsync().GetAwaiter().GetResult();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(OurTeamViewComponent), ": ", ex.Message), ex);
                
                _httpContextAccessor?.HttpContext?.Response.Redirect("/Home/ApplicationError");

                return View(new List<OurTeamViewModel>());
            }
        }
    }
}
