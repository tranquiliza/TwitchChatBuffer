using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core.Domain;
using Tranquiliza.BufferedChat.Core.Services;

namespace Tranquiliza.BufferedChat.Core
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageHub _messageHub;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ChatMessageService(IMessageRepository messageRepository, IMessageHub messageHub, IDateTimeProvider dateTimeProvider)
        {
            _messageRepository = messageRepository;
            _messageHub = messageHub;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task CreateAndSaveMessage(
            string channel,
            string message,
            string username,
            string userColorHex,
            string userId,
            string emoteReplacedMessage,
            string displayName)
        {
            var chatMessage = new ChatMessage(channel, message, username, userColorHex, userId, emoteReplacedMessage, displayName, _dateTimeProvider.UtcNow);

            await _messageRepository.AddMessage(chatMessage).ConfigureAwait(false);
            await _messageRepository.SaveChanges().ConfigureAwait(false);
            await _messageHub.SendMessage(chatMessage).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ChatMessage>> GetLatestMessages(string channelName, int pageSize)
        {
            return await _messageRepository.GetLatestMessages(channelName, pageSize).ConfigureAwait(false);
        }
    }
}
