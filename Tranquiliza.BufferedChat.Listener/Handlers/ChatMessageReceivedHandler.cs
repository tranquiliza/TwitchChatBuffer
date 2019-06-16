using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Listener.Services;
using Tranquiliza.BufferedChat.Listener.Twitch;

namespace Tranquiliza.BufferedChat.Listener.Handlers
{
    public class ChatMessageReceivedHandler : INotificationHandler<MessageReceivedEvent>
    {
        private readonly IChatMessageService _chatMessageService;

        public ChatMessageReceivedHandler(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }

        public async Task Handle(MessageReceivedEvent notification, CancellationToken cancellationToken)
        {
            await _chatMessageService.CreateAndSaveMessage(notification).ConfigureAwait(false);


        }
    }
}
