using InteriorDesign.Core.Services.Common.ChatService;
using InteriorDesign.Core.ViewModels.ChatViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Areas.Employee.Controllers
{
    public class ChatController : BaseEmployeeController
    {
        private bool isHistoryLoaded = false;
        private readonly IChatService _chatService;
        private readonly ILogger _logger;

        public ChatController(
            IChatService chatService, 
            ILogger<ChatController> logger)
        {
            _chatService = chatService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (isHistoryLoaded)
            {
                return View();
            }

            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception");

                var model = await _chatService.GetAllMessagesAsync();

                isHistoryLoaded = true;

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ChatController), nameof(Index));
            }
        }
    }
}
