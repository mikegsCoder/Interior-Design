using InteriorDesign.Core.Services.Common.ChatService;
using InteriorDesign.Core.ViewModels.ChatViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    public class ChatController : BaseAdminController
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

        [HttpPost]
        public async Task<string> SaveMessage(ChatViewModel model)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception!");

                await _chatService.SaveMessageAsync(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(ChatController), " - ", nameof(SaveMessage), ": ", ex.Message), ex);
            }

            return null;
        }

        [HttpGet]
        public async Task<IActionResult> ClearChatHistory()
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test exception!");

                await _chatService.ClearChatHistoryAsync();

                isHistoryLoaded = false;

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToError(ex, _logger, nameof(ChatController), nameof(ClearChatHistory));
            }
        }
    }
}
