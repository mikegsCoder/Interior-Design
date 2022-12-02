using InteriorDesign.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Policy = "RequireEmployeeOnly")]
    public class BaseEmployeeController : Controller
    {
        internal RedirectResult RedirectToError(Exception ex, ILogger logger, string controllerName, string actionName)
        {
            logger.LogError(string.Concat(controllerName, " - ", actionName, ": ", ex.Message), ex);

            TempData["Error"] = ex.Message;

            return Redirect(WebConstants.EmployeeError);
        }
    }
}
