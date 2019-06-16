using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Listener.Twitch;

namespace Tranquiliza.BufferedChat.Listener.Services
{
    public interface IChatMessageService
    {
        Task CreateAndSaveMessage(MessageReceivedEvent messageReceivedEvent);
    }
}