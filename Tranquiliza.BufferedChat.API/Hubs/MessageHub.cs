using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.API.Contracts;
using Tranquiliza.BufferedChat.Core.Domain;
using Tranquiliza.BufferedChat.Core.Services;

namespace Tranquiliza.BufferedChat.API.Hubs
{
    public class MessageHub : Hub, IMessageHub
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public MessageHub(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessage(ChatMessage chatMessage)
            => await _hubContext.Clients.All.SendAsync("ReceiveMessage", ChatMessageContract.Create(chatMessage)).ConfigureAwait(false);
    }
}
