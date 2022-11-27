using InteriorDesign.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Controllers
{
    public class BaseController : Controller
    {
        internal RedirectResult RedirectToError(Exception ex, ILogger logger, string controllerName, string actionName)
        {
            logger.LogError(string.Concat(controllerName, " - ", actionName, ": ", ex.Message), ex);

            return Redirect(WebConstants.UserError);
        }
    }
}
