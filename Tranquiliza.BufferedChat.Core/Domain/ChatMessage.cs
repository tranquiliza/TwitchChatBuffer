using System;
using System.Collections.Generic;
using System.Text;

namespace Tranquiliza.BufferedChat.Core
{
    public class ChatMessage
    {
        public Guid Id { get; private set; }
        public DateTime ReceivedAt { get; private set; }
        public string Channel { get; private set; }
        public string Message { get; private set; }
        public string Username { get; private set; }
        public string UserColorHex { get; private set; }
        public string UserId { get; private set; }
        public string EmoteReplacedMessage { get; private set; }
        public string DisplayName { get; private set; }

        [Obsolete("For serialization only", true)]
        public ChatMessage() { }

        public ChatMessage(string channel, string message, string username, string userColorHex, string userId, string emoteReplacedMessage, string displayName, DateTime receivedAt)
        {
            Channel = channel;
            Message = message;
            Username = username;
            UserColorHex = userColorHex;
            UserId = userId;
            EmoteReplacedMessage = emoteReplacedMessage;
            DisplayName = displayName;
            ReceivedAt = receivedAt;
        }
    }
}
