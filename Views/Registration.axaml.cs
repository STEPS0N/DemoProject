using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoProject.Classes;
using DemoProject.Services;
using DemoProject.ViewModels;

namespace DemoProject;

public partial class Registration : UserControl
{
    public Registration()
    {
        InitializeComponent();
        var userService = new UserService();
        DataContext = new Resiter_VM(userService);
    }

    private void ToAuthorise(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationService.NavigateTo(new Authorisation());
    }
}