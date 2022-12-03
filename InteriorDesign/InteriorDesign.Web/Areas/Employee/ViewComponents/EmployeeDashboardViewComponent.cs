using InteriorDesign.Core.Services.Employee.DashboardService;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Employee.ViewComponents
{
    [ViewComponent(Name = "EmployeeDashboard")]
    public class EmployeeDashboardViewComponent : ViewComponent
    {
        private readonly IEmployeeDashboardService _service;

        public EmployeeDashboardViewComponent(IEmployeeDashboardService service)
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
