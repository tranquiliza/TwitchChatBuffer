using System;
using System.Collections.Generic;
using System.Text;

namespace Tranquiliza.BufferedChat.Core.Domain
{
    public class User
    {
        public Guid Id { get; private set; }

        public string TwitchUsername { get; private set; }

        public List<Integration> Integrations { get; private set; } = new List<Integration>();

        [Obsolete("Only for serilizations", true)]
        public User() { }

        public User(string twitchUsername)
        {
            TwitchUsername = twitchUsername;
        }

        public void AddIntegration(string integrationUrl, bool isVisible)
        {
            Integrations.Add(new Integration(integrationUrl, isVisible));
        }
    }
}
