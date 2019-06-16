using System;
using System.Collections.Generic;
using System.Text;

namespace Tranquiliza.BufferedChat.Listener.Twitch
{
    public class TwitchClientSettings
    {
        public string TwitchUsername { get; set; }
        public string TwitchBotOAuth { get; set; }

        public TwitchClientSettings(string twitchUsername, string twitchBotOAuth)
        {
            TwitchUsername = twitchUsername;
            TwitchBotOAuth = twitchBotOAuth;
        }
    }
}
