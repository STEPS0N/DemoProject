using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoProject.Models;
using DemoProject.Services;
using MsBox.Avalonia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.ViewModels
{
    public partial class NewsViewModel : ObservableObject
    {
        private readonly NewsService _newsService;
        private NewsHubService? _hubService;
        [ObservableProperty]
        private ObservableCollection<Models.News> _news = new ObservableCollection<Models.News>();

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private bool _isConnected;

        public NewsViewModel(NewsService newsService)
        {
            _newsService = newsService; 
        }

        public async Task InitAsync(string token)
        {
            await LoadNewsAsync();
            await ConnectToHubAsync(token);
        }

        [RelayCommand]
        private async Task LoadNewsAsync()
        {
            IsLoading = true;

            try
            {
                var newsList = await _newsService.GetNewsAsync();
                News = new ObservableCollection<Models.News>(newsList);
            } 
            catch(Exception ex)
            {
                await MessageBoxManager.GetMessageBoxStandard("Заголовок", $"{ex.Message}").ShowAsync();
            }
            finally
            {
                IsLoading = false;
            }

        }

        private async Task ConnectToHubAsync(string token)
        {
            try
            {
                _hubService = new NewsHubService(token);
                
                _hubService.OnNewsReceived += (news) =>
                {
                    Avalonia.Threading.Dispatcher.UIThread.Post(() =>
                    {
                        News.Insert(0, news);
                    });
                };

                _hubService.OnNewsListReceived += (newsList) =>
                {
                    Avalonia.Threading.Dispatcher.UIThread.Post(() =>
                    {
                        News = new ObservableCollection<Models.News>(newsList);
                    });
                };

                await _hubService.StartAsync();
                IsConnected = true;
            }
            catch (Exception ex)
            {
                await MessageBoxManager.GetMessageBoxStandard("Заголовок", $"{ex.Message}").ShowAsync();
            }
        }

        [RelayCommand]
        private void Refresh()
        {
            LoadNewsAsync();
        }

        public async Task DisconnectAsync()
        {
            if(_hubService != null)
            {
                await _hubService.StopAsync();
                IsConnected = false;
            }
        }
    }
}
