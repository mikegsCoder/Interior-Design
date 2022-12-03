using InteriorDesign.Core.Services.Administration.DashboardService;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Administration.ViewComponents
{
    [ViewComponent(Name = "AdminDashboard")]
    public class AdminDashboardViewComponent : ViewComponent
    {
        private readonly IAdminDashboardService _service;

        public AdminDashboardViewComponent(IAdminDashboardService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            var model = _service.GetDashboardInfo().GetAwaiter().GetResult();

            return View(model);
        }
    }
}
