using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tranquiliza.BufferedChat.Core
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public ChatMessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task CreateAndSaveMessage(ChatMessage message)
        {
            await _messageRepository.AddMessage(message).ConfigureAwait(false);
            await _messageRepository.SaveChanges().ConfigureAwait(false);
        }

        public async Task<IEnumerable<ChatMessage>> GetLatestMessages(string channelName, int pageSize)
        {
            return await _messageRepository.GetLatestMessages(channelName, pageSize).ConfigureAwait(false);
        }
    }
}
