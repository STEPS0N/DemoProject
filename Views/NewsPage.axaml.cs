using Avalonia.Controls;
using DemoProject.Services;
using DemoProject.ViewModels;

namespace DemoProject;

public partial class News : UserControl
{
    public News()
    {
        InitializeComponent();
        var _newsService = new NewsService();
        DataContext = new NewsViewModel(_newsService);
    }
}