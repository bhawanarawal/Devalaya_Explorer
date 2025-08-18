using Devalaya.Explorer.Web.Hubs;
using Devalaya.Explorer.Web.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using OllamaSharp;

namespace Devalaya.Explorer.Web.Controllers
{
    public class ChatController : Controller
    {
        private readonly OllamaSettings _ollamaSettings;
        private readonly IHubContext<OllamaHub> _hubContext;

        public ChatController(IHubContext<OllamaHub> hubContext, IOptions<OllamaSettings> ollamaSettings)
        {
            _ollamaSettings=ollamaSettings.Value;
            _hubContext = hubContext;
        }
        [HttpGet] 

        public async Task<IActionResult> Index(string message)
        {
            IChatClient chatClient = new OllamaApiClient (new Uri(_ollamaSettings.Url), _ollamaSettings.Model);
            List<ChatMessage> chatHistory = new();
            chatHistory.Add(new ChatMessage(ChatRole.User, message));

            await foreach (ChatResponseUpdate item in chatClient.GetStreamingResponseAsync(chatHistory))
            {
                Console.Write(item.Text);
               await _hubContext.Clients.All.SendAsync("ReceiveOllamaResponse", item.Text);
            }
            return Ok();
        
        }

    }
}
