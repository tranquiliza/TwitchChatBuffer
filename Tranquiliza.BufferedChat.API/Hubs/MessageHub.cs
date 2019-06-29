using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core;

namespace Tranquiliza.BufferedChat.API.Hubs
{
    public class MessageHub : Hub
    {
        public Task SendMessage(ChatMessage chatMessage)
        {
            return Clients.All.SendAsync("ReceiveMessage", chatMessage);
        }
    }
}
