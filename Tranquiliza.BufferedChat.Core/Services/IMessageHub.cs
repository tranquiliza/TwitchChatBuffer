using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core.Domain;

namespace Tranquiliza.BufferedChat.Core.Services
{
    public interface IMessageHub
    {
        Task SendMessage(ChatMessage chatMessage);
    }
}
