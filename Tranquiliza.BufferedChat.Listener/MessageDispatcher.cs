using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core;
using Tranquiliza.BufferedChat.Core.Domain;
using Tranquiliza.BufferedChat.Listener.Twitch;

namespace Tranquiliza.BufferedChat.Listener
{
    public class MessageDispatcher : IMessageDispatcher
    {
        private readonly IEndpointConfiguration _configuration;

        public MessageDispatcher(IEndpointConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Dispatch(MessageReceivedEvent chatMessage)
        {
            var api = _configuration.ApiAddress.AppendPathSegments("api", "messages");

            try
            {
                await api.PostJsonAsync(chatMessage).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
