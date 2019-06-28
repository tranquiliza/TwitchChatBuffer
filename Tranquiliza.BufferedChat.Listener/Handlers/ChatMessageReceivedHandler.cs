using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core;
using Tranquiliza.BufferedChat.Listener.Twitch;

namespace Tranquiliza.BufferedChat.Listener.Handlers
{
    public class ChatMessageReceivedHandler : INotificationHandler<MessageReceivedEvent>
    {
        private readonly IChatMessageService _chatMessageService;
        private readonly IChatEventTranslator _chatEventTranslator;

        public ChatMessageReceivedHandler(IChatMessageService chatMessageService, IChatEventTranslator chatEventTranslator)
        {
            _chatMessageService = chatMessageService;
            _chatEventTranslator = chatEventTranslator;
        }

        public async Task Handle(MessageReceivedEvent notification, CancellationToken cancellationToken)
        {
            var message = _chatEventTranslator.Translate(notification);
            await _chatMessageService.CreateAndSaveMessage(message).ConfigureAwait(false);
        }
    }
}
