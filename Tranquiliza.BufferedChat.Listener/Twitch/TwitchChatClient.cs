using System;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace Tranquiliza.BufferedChat.Listener.Twitch
{
    public class TwitchChatClient : ITwitchChatClient
    {
        private readonly TwitchClient _twitchClient;

        public TwitchChatClient(TwitchClientSettings twitchClientSettings, bool shouldReplateEmotes = false)
        {
            var credentials = new ConnectionCredentials(twitchClientSettings.TwitchUsername, twitchClientSettings.TwitchBotOAuth);

            _twitchClient = new TwitchClient
            {
                WillReplaceEmotes = shouldReplateEmotes
            };

            _twitchClient.Initialize(credentials);
            _twitchClient.OnMessageReceived += TwitchClient_OnMessageReceived;
        }

        public event EventHandler<MessageReceivedEvent> OnMessageReceived;

        private void TwitchClient_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            Task.Run(() => OnMessageReceived?.Invoke(this, e.Map()));
        }

        private TaskCompletionSource<bool> _connectionCompletionTask = new TaskCompletionSource<bool>();

        public event EventHandler OnConnected;

        public async Task Connect()
        {
            _twitchClient.OnConnected += TwitchClient_OnConnected;
            _twitchClient.Connect();

            await _connectionCompletionTask.Task;
        }

        private void TwitchClient_OnConnected(object sender, OnConnectedArgs e)
        {
            _twitchClient.OnConnected -= TwitchClient_OnConnected;

            OnConnected?.Invoke(this, null);

            _connectionCompletionTask.SetResult(true);
            _connectionCompletionTask = new TaskCompletionSource<bool>();
        }

        public Task Disconnect()
        {
            foreach (var joinedChannel in _twitchClient.JoinedChannels)
                _twitchClient.LeaveChannel(joinedChannel);

            _twitchClient.Disconnect();

            return Task.CompletedTask;
        }

        public Task JoinChannel(string channelName)
        {
            _twitchClient.JoinChannel(channelName);

            return Task.CompletedTask;
        }
    }
}
