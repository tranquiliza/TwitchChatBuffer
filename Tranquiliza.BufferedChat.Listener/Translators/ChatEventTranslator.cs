using System;
using System.Collections.Generic;
using System.Text;
using Tranquiliza.BufferedChat.Core;
using Tranquiliza.BufferedChat.Listener.Twitch;

namespace Tranquiliza.BufferedChat.Listener
{
    public class ChatEventTranslator : IChatEventTranslator
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public ChatEventTranslator(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public ChatMessage Translate(MessageReceivedEvent notification)
        {
            return new ChatMessage(
                notification.Channel,
                notification.Message,
                notification.Username,
                notification.UserColorHex,
                notification.UserId,
                notification.EmoteReplacedMessage,
                notification.DisplayName,
                _dateTimeProvider.UtcNow);
        }
    }
}
