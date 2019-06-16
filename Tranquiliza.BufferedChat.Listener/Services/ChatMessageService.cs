using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core;
using Tranquiliza.BufferedChat.Listener.Twitch;

namespace Tranquiliza.BufferedChat.Listener.Services
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IMessageRepository _messageRepository;

        public ChatMessageService(IMessageRepository messageRepository, IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
            _messageRepository = messageRepository;
        }

        public async Task CreateAndSaveMessage(MessageReceivedEvent msgReceivedEvent)
        {
            var message = new ChatMessage(
                msgReceivedEvent.Channel,
                msgReceivedEvent.Message,
                msgReceivedEvent.Username,
                msgReceivedEvent.UserColorHex,
                msgReceivedEvent.UserId,
                msgReceivedEvent.EmoteReplacedMessage,
                msgReceivedEvent.DisplayName,
                _dateTimeProvider.UtcNow);

            await _messageRepository.AddMessage(message).ConfigureAwait(false);
            await _messageRepository.SaveChanges().ConfigureAwait(false);
        }
    }
}
