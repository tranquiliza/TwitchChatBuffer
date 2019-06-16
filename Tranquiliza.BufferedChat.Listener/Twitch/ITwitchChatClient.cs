using System;
using System.Threading.Tasks;

namespace Tranquiliza.BufferedChat.Listener.Twitch
{
    public interface ITwitchChatClient
    {
        event EventHandler<MessageReceivedEvent> OnMessageReceived;

        Task Connect();
        Task Disconnect();
        Task JoinChannel(string channelName);
    }
}