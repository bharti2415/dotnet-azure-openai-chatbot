using Microsoft.AspNetCore.Mvc;
using ChatbotApp.Services;

namespace ChatbotApp.Controllers
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
        public async Task<IActionResult> Post([FromBody] ChatRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
                return BadRequest("Message cannot be empty.");

            var reply = await _chatService.GetResponseAsync(request.Message);
            return Ok(new { Reply = reply });
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; }
    }
}
