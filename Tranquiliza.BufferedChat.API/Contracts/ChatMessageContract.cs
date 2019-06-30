using System;
using Tranquiliza.BufferedChat.Core.Domain;

namespace Tranquiliza.BufferedChat.API.Contracts
{
    public class ChatMessageContract
    {
        public Guid Id { get; private set; }
        public DateTime ReceivedAt { get; private set; }
        public string Channel { get; private set; }
        public string Message { get; private set; }
        public string UserColorHex { get; private set; }
        public string EmoteReplacedMessage { get; private set; }
        public string DisplayName { get; private set; }

        public static ChatMessageContract Create(ChatMessage message)
        {
            var receivedAt = message.ReceivedAt;

            return new ChatMessageContract
            {
                Id = message.Id,
                Channel = message.Channel,
                DisplayName = message.DisplayName,
                EmoteReplacedMessage = message.EmoteReplacedMessage,
                Message = message.Message,
                ReceivedAt = new DateTime(receivedAt.Ticks - (receivedAt.Ticks % TimeSpan.TicksPerSecond), receivedAt.Kind),
                UserColorHex = message.UserColorHex
            };
        }
    }
}
