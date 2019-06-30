using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core;
using Tranquiliza.BufferedChat.Core.Domain;
using Tranquiliza.BufferedChat.Listener.Twitch;

namespace Tranquiliza.BufferedChat.Listener
{
    public interface IMessageDispatcher
    {
        Task Dispatch(MessageReceivedEvent chatMessage);
    }
}
