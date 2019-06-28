using Tranquiliza.BufferedChat.Core;
using Tranquiliza.BufferedChat.Listener.Twitch;

namespace Tranquiliza.BufferedChat.Listener
{
    public interface IChatEventTranslator
    {
        ChatMessage Translate(MessageReceivedEvent notification);
    }
}