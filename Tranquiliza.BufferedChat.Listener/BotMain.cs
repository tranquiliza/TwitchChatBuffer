using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Listener.Twitch;

namespace Tranquiliza.BufferedChat.Listener
{
    public class BotMain
    {
        private readonly ITwitchChatClient _twitchChatClient;
        private readonly IMediator _mediator;

        public BotMain(ITwitchChatClient twitchChatClient, IMediator mediator)
        {
            _twitchChatClient = twitchChatClient;
            _twitchChatClient.OnMessageReceived += TwitchChatClient_OnMessageReceived;
            _mediator = mediator;
        }

        private void TwitchChatClient_OnMessageReceived(object sender, MessageReceivedEvent e)
        {
            _mediator.Publish(e);
        }

        public async Task Start()
        {
            await _twitchChatClient.Connect().ConfigureAwait(false);

            await _twitchChatClient.JoinChannel("tranquiliza").ConfigureAwait(false);
        }

        public async Task Stop()
        {
            await _twitchChatClient.Disconnect().ConfigureAwait(false);
        }
    }
}
