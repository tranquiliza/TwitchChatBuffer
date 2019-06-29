using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core;

namespace Tranquiliza.BufferedChat.Listener
{
    public class MessageDispatcher : IMessageDispatcher
    {
        private readonly IEndpointConfiguration _configuration;

        public MessageDispatcher(IEndpointConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Dispatch(ChatMessage chatMessage)
        {
            var api = _configuration.EndPoint.AppendPathSegments("api", "messages");

            await api.PostJsonAsync(chatMessage).ConfigureAwait(false);
        }
    }
}
