using Microsoft.AspNetCore.SignalR;

namespace Devalaya.Explorer.Web.Hubs;

public class OllamaHub: Hub
{
    public async Task OllamaResponse(string message)
    {
        // Broadcast the message to all connected clients
        await Clients.All.SendAsync("ReceiveOllamaResponse", message);
    }
}
