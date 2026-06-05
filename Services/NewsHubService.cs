using Avalonia.Metadata;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Services
{
    public class NewsHubService : IAsyncDisposable
    {
        private readonly HubConnection _connection;
        public event Action<Models.News>? OnNewsReceived;
        public event Action<List<Models.News>>? OnNewsListReceived;

        public NewsHubService(string token)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7088/newsHub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(token)!;

                    options.HttpMessageHandlerFactory = _ => new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (_, _, _, _) => true
                    };
                })
                .WithAutomaticReconnect()
                .Build();

            RegisterHandlers();
        }

        private void RegisterHandlers()
        {
            _connection.On<Models.News>("ReceiveNews", news =>
            {
                OnNewsReceived?.Invoke(news);
            });

            _connection.On<List<Models.News>>("ReceiveNewsList", newsList =>
            {
                OnNewsListReceived?.Invoke(newsList);
            });
        }

        public async Task StartAsync()
        {
            if (_connection.State == HubConnectionState.Disconnected)
                await _connection.StartAsync();
        }

        public async Task StopAsync()
        {
            if (_connection.State == HubConnectionState.Connected)
                await _connection.StopAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _connection.DisposeAsync();
        }
    }
}
