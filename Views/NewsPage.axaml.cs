using Avalonia.Controls;
using DemoProject.ViewModels;

namespace DemoProject;

public partial class News : UserControl
{
    public News()
    {
        InitializeComponent();
        DataContext = new NewsViewModel();
    }
}