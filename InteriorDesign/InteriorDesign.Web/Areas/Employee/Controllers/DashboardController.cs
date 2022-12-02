using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Areas.Employee.Controllers
{
    public class DashboardController : BaseEmployeeController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EmployeeError()
        {
            return View();
        }
    }
}
