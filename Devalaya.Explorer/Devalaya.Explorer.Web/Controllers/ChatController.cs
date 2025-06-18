using Devalaya.Explorer.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.AI;
using OllamaSharp;

namespace Devalaya.Explorer.Web.Controllers
{
    public class ChatController : Controller
    {
        private readonly IHubContext<OllamaHub> _hubContext;

        public ChatController(IHubContext<OllamaHub> hubContext)
        {
         _hubContext = hubContext;
        }
        [HttpGet] 

        public async Task<IActionResult> Index(string message)
        {
            IChatClient chatClient = new OllamaApiClient(new Uri("http://localhost:11434"), "phi3:mini");
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
