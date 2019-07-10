using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tranquiliza.BufferedChat.API.Contracts
{
    public class IntegrationContract
    {
        public Guid Id { get; set; }
        public string IntegrationUrl { get; set; }
        public bool IsVisible { get; set; }
    }
}
