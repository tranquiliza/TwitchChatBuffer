using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tranquiliza.BufferedChat.Listener.TcpSocket
{
    public class TcpMessageRelayer : IMessageRelayer
    {
        public TcpMessageRelayer(string hostname, int port)
        {
            var socket = new TcpListener(IPAddress.Any, port);
        }
    }
}
