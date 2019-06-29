using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tranquiliza.BufferedChat.Core
{
    public class ChatMessage
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("receivedAt")]
        public DateTime ReceivedAt { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("userColorHex")]
        public string UserColorHex { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("emoteReplacedMessage")]
        public string EmoteReplacedMessage { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

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
