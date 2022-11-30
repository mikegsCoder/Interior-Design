using InteriorDesign.Core.Services.Application.OurTeamService;
using InteriorDesign.Core.ViewModels.OurTeamViewModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.ViewComponents
{
    [ViewComponent(Name = "OurTeam")]
    public class OurTeamViewComponent : ViewComponent
    {
        private readonly IOurTeamService _ourTeamService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;

        public OurTeamViewComponent(
            IOurTeamService ourTeamService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<OurTeamViewComponent> logger,
            IMemoryCache cache)
        {
            _ourTeamService = ourTeamService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _cache= cache;
        }

        public IViewComponentResult Invoke()
        {
            if (!_cache.TryGetValue<IEnumerable<OurTeamViewModel>>("OurTeam", out var model))
            {
                try
                {
                    // Use this exception to test error handling:
                    //throw new Exception("Test Exception");

                    model = _ourTeamService.GetTeamAsync().GetAwaiter().GetResult();

                    _cache.Set("OurTeam", model, TimeSpan.FromMinutes(5));
                }
                catch (Exception ex)
                {
                    _logger.LogError(string.Concat(nameof(OurTeamViewComponent), ": ", ex.Message), ex);

                    _httpContextAccessor?.HttpContext?.Response.Redirect("/Home/ApplicationError");

                    return View(new List<OurTeamViewModel>());
                }
            }

            return View(model);

            //try
            //{
            //    // Use this exception to test error handling:
            //    //throw new Exception("Test Exception");

            //    var model = _ourTeamService.GetTeamAsync().GetAwaiter().GetResult();

            //    return View(model);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(string.Concat(nameof(OurTeamViewComponent), ": ", ex.Message), ex);
                
            //    _httpContextAccessor?.HttpContext?.Response.Redirect("/Home/ApplicationError");

            //    return View(new List<OurTeamViewModel>());
            //}
        }
    }
}
