using Microsoft.AspNetCore.Mvc;
using ChatbotApi.Services;

namespace ChatbotApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserMessage request)
        {
            var response = await _chatService.GetResponseAsync(request.Message);
            return Ok(new { reply = response });
        }
    }

    public class UserMessage
    {
        public string Message { get; set; }
    }
}
