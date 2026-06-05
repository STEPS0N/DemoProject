using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoProject.Models;
using System;
using System.Collections.Generic;

namespace DemoProject;

public partial class News : UserControl
{
    public News()
    {
        InitializeComponent();

        var items = new List<News>
        {
            new Models.News { Title = "Крупное обновление", Description = "Мы улучшили шифрование данных.", CreatedAt = DateTime.Now },
            new News { Title = "Новые функции", Description = "Теперь можно управлять сессиями.", CreatedAt = DateTime.Now.AddDays(-1) },
            new News { Title = "Технические работы", Description = "Серверы будут обновлены ночью.", CreatedAt = DateTime.Now.AddDays(-3) }
        };

        newsList.ItemsSource = items;
    }
}