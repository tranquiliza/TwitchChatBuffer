using MediatR;
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
        private readonly IMessageDispatcher _messageDispatcher;

        public ChatMessageReceivedHandler(IChatMessageService chatMessageService, IChatEventTranslator chatEventTranslator, IMessageDispatcher messageDispatcher)
        {
            _chatMessageService = chatMessageService;
            _chatEventTranslator = chatEventTranslator;
            _messageDispatcher = messageDispatcher;
        }

        public async Task Handle(MessageReceivedEvent notification, CancellationToken cancellationToken)
        {
            var message = _chatEventTranslator.Translate(notification);
            await _chatMessageService.CreateAndSaveMessage(message).ConfigureAwait(false);
            await _messageDispatcher.Dispatch(message).ConfigureAwait(false);
        }
    }
}
