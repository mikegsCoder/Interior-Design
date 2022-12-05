using InteriorDesign.Core.Constants;
using InteriorDesign.Core.Services.Application.OurTeamService;
using InteriorDesign.Core.ViewModels.OurTeamViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Administration.ViewComponents
{
    [ViewComponent(Name = "AdminOurTeam")]
    public class AdminOurTeamViewComponent : ViewComponent
    {
        private readonly IOurTeamService _ourTeamService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public AdminOurTeamViewComponent(
            IOurTeamService ourTeamService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<AdminOurTeamViewComponent> logger)
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
                _logger.LogError(string.Concat(nameof(AdminOurTeamViewComponent), ": ", ex.Message), ex);

                TempData["Error"] = ex.Message;

                _httpContextAccessor?.HttpContext?.Response.Redirect(WebConstants.AdminError);

                return View(new List<OurTeamViewModel>());
            }
        }
    }
}
