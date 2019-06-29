using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core;

namespace Tranquiliza.BufferedChat.API.Controllers
{
    [Route("api/messages")]
    public class MessageController : ControllerBase
    {
        private class ChatMessageContract
        {
            public Guid Id { get; private set; }
            public DateTime ReceivedAt { get; private set; }
            public string Channel { get; private set; }
            public string Message { get; private set; }
            public string UserColorHex { get; private set; }
            public string EmoteReplacedMessage { get; private set; }
            public string DisplayName { get; private set; }

            public static ChatMessageContract Create(
                ChatMessage message)
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

        private readonly IChatMessageService _chatMessageService;

        public MessageController(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }

        [Route("")]
        public async Task<IActionResult> Messages(string channelName, int pageSize = 20)
        {
            var result = await _chatMessageService.GetLatestMessages(channelName, pageSize).ConfigureAwait(false);
            return Ok(result.Select(ChatMessageContract.Create));
        }
    }
}
