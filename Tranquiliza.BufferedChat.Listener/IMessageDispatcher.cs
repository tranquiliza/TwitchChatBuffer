using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core;

namespace Tranquiliza.BufferedChat.Listener
{
    public interface IMessageDispatcher
    {
        Task Dispatch(ChatMessage chatMessage);
    }
}
