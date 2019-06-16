using MediatR;

namespace Tranquiliza.BufferedChat.Listener.Twitch
{
    public class MessageReceivedEvent : INotification
    {
        public string Channel { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string UserColorHex { get; internal set; }
        public string UserId { get; internal set; }
        public string EmoteReplacedMessage { get; internal set; }
        public string DisplayName { get; internal set; }
    }
}
