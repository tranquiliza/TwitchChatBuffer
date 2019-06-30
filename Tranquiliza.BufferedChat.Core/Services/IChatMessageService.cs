using System.Collections.Generic;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core.Domain;

namespace Tranquiliza.BufferedChat.Core
{
    public interface IChatMessageService
    {
        Task CreateAndSaveMessage(
            string channel,
            string message,
            string username,
            string userColorHex,
            string userId,
            string emoteReplacedMessage,
            string displayName);

        Task<IEnumerable<ChatMessage>> GetLatestMessages(string channelName, int pageSize);
    }
}