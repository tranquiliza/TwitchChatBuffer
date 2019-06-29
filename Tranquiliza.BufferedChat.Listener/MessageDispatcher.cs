using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

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
