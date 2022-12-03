using InteriorDesign.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class BaseAdminController : Controller
    {
        internal RedirectResult RedirectToError(Exception ex, ILogger logger, string controllerName, string actionName)
        {
            logger.LogError(string.Concat(controllerName, " - ", actionName, ": ", ex.Message), ex);

            TempData["Error"] = ex.Message;

            return Redirect(WebConstants.AdminError);
        }
    }
}
