using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core.Domain;

namespace Tranquiliza.BufferedChat.Core
{
    public interface IMessageRepository
    {
        Task SaveChanges();
        Task AddMessage(ChatMessage chatMessage);
        Task<IEnumerable<ChatMessage>> GetLatestMessages(string channelName, int pageSize);
    }
}
