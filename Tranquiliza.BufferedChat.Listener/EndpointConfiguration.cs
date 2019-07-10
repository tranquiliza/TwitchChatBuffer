using System;
using System.Collections.Generic;
using System.Text;

namespace Tranquiliza.BufferedChat.Listener
{
    public class EndpointConfiguration : IEndpointConfiguration
    {
        public string ApiAddress { get; private set; }

        public EndpointConfiguration(string apiAddress = "https://localhost:44374/")
        {
            ApiAddress = apiAddress;
        }
    }
}
