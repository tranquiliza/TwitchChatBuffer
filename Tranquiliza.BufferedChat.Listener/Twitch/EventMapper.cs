using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client.Events;

namespace Tranquiliza.BufferedChat.Listener.Twitch
{
    internal static class EventMapper
    {
        internal static MessageReceivedEvent Map(this OnMessageReceivedArgs from)
        {
            var chatMessage = from.ChatMessage;
            return new MessageReceivedEvent()
            {
                Channel = chatMessage.Channel,
                DisplayName = chatMessage.DisplayName,
                EmoteReplacedMessage = chatMessage.EmoteReplacedMessage,
                Message = chatMessage.Message,
                UserColorHex = chatMessage.ColorHex,
                UserId = chatMessage.UserId,
                Username = chatMessage.Username
            };
        }
    }
}
