﻿namespace Tranquiliza.BufferedChat.API.Contracts
{
    public class CreateChatMessageContract
    {
        public string Channel { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string UserColorHex { get; set; }
        public string UserId { get; set; }
        public string EmoteReplacedMessage { get; set; }
        public string DisplayName { get; set; }
    }
}
