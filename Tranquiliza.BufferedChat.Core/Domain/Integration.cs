using System;
using System.Collections.Generic;
using System.Text;

namespace Tranquiliza.BufferedChat.Core.Domain
{
    public class Integration
    {
        public Guid Id { get; private set; }
        public string IntegrationUrl { get; private set; }
        public bool Visible { get; private set; }

        [Obsolete("For serilization only", true)]
        public Integration() { }

        public Integration(string integrationUrl, bool visible)
        {
            IntegrationUrl = integrationUrl;
            Visible = visible;
        }
    }
}
