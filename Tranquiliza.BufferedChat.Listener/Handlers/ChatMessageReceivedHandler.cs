using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Listener.Twitch;

namespace Tranquiliza.BufferedChat.Listener.Handlers
{
    public class ChatMessageReceivedHandler : INotificationHandler<MessageReceivedEvent>
    {
        private readonly IMessageDispatcher _messageDispatcher;

        public ChatMessageReceivedHandler(IMessageDispatcher messageDispatcher)
        {
            _messageDispatcher = messageDispatcher;
        }

        public async Task Handle(MessageReceivedEvent notification, CancellationToken cancellationToken)
        {
            await _messageDispatcher.Dispatch(notification).ConfigureAwait(false);
        }
    }
}
