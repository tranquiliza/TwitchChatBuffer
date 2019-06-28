using System.Threading.Tasks;

namespace Tranquiliza.BufferedChat.Core
{
    public interface IChatMessageService
    {
        Task CreateAndSaveMessage(ChatMessage message);
    }
}