using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tranquiliza.BufferedChat.Listener
{
    public class ServiceHost : IHostedService
    {
        private readonly BotMain _botMain;

        public ServiceHost(BotMain botMain)
        {
            _botMain = botMain;
        }

        public Task StartAsync(CancellationToken cancellationToken) => _botMain.Start();

        public Task StopAsync(CancellationToken cancellationToken) => _botMain.Stop();
    }
}
