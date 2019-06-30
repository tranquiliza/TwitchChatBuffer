using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core.Domain;

namespace Tranquiliza.BufferedChat.API.Contracts
{
    public class UserContract
    {
        public Guid Id { get; set; }

        public string TwitchUsername { get; set; }

        public List<IntegrationContract> Integrations { get; set; }

        public static UserContract Create(User user)
        {
            return new UserContract
            {
                Id = user.Id,
                TwitchUsername = user.TwitchUsername,
                Integrations = user.Integrations.Select(integration => new IntegrationContract
                {
                    IntegrationUrl = integration.IntegrationUrl,
                    IsVisible = integration.Visible
                }).ToList()
            };
        }
    }
}
