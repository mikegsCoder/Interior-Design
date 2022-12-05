using InteriorDesign.Core.Services.Application.OurTeamService;
using InteriorDesign.Core.ViewModels.OurTeamViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    public class OurTeamController : BaseAdminController
    {
        private readonly IOurTeamService _ourTeamService;
        private readonly ILogger _logger;

        public OurTeamController(
            IOurTeamService ourTeamService, 
            ILogger<OurTeamController> logger)
        {
            _ourTeamService = ourTeamService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
