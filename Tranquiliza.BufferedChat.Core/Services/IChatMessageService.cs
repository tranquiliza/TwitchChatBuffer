using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tranquiliza.BufferedChat.Core
{
    public interface IChatMessageService
    {
        Task CreateAndSaveMessage(ChatMessage message);

        Task<IEnumerable<ChatMessage>> GetLatestMessages(string channelName, int pageSize);
    }
}