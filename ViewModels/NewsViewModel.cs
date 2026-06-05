using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.ViewModels
{
    public partial class NewsViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<Models.News> _news = new ObservableCollection<Models.News>();

        [ObservableProperty]
        private bool _isLoading;

        public NewsViewModel()
        {
            LoadNews();
        }

        private void LoadNews()
        {
            IsLoading = true;

            News = new ObservableCollection<Models.News>
            {
                new Models.News { Title = "Крупное обновление", Description = "Мы улучшили шифрование данных.", CreatedAt = DateTime.Now },
                new Models.News { Title = "Новые функции", Description = "Теперь можно управлять сессиями.", CreatedAt = DateTime.Now.AddDays(-1) },
                new Models.News { Title = "Технические работы", Description = "Серверы будут обновлены ночью.", CreatedAt = DateTime.Now.AddDays(-3) }
            };

            IsLoading = false;
        }

        [RelayCommand]
        private void Refresh()
        {
            LoadNews();
        }
    }
}
