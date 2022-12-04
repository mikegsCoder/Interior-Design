using Microsoft.AspNetCore.Mvc;
using InteriorDesign.Core.Constants;
using InteriorDesign.Core.Services.Administration.AccountService;

namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    public class AccountsController : BaseAdminController
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string message)
        {
            var model = await _service.GetAccountsInfoAsync();

            model.Message = message;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MakeAccountEmployee(string id)
        {
            var result = await _service.MakeUserEmployeeAsync(id);

            var message = result ? MessageConstants.Success : MessageConstants.Failed;

            return RedirectToAction(nameof(Index), new { message = message });
        }

        [HttpGet]
        public async Task<IActionResult> MakeAccountAdmin(string id)
        {
            var result = await _service.MakeUserAdministratorAsync(id);

            var message = result ? MessageConstants.Success : MessageConstants.Failed;

            return RedirectToAction(nameof(Index), new { message = message });
        }
    }
}
