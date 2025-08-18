using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.AI;
using OllamaSharp;

namespace Devalaya.Explorer.Web.Hubs
{
    public class OllamaHub : Hub
    {
        public async Task SendOllamaRequest(string message)
        {
            IChatClient chatClient = new OllamaApiClient(new Uri("http://localhost:11434"), "phi3:mini");
            List<ChatMessage> chatHistory = new() { new ChatMessage(ChatRole.User, message) };

           
            await foreach (var item in chatClient.GetStreamingResponseAsync(chatHistory))
            {
                await Clients.Caller.SendAsync("ReceiveOllamaResponse", item.Text);
            }
        }
    }
}
