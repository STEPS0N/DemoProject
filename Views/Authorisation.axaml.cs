using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoProject.Classes;
using DemoProject.Services;
using DemoProject.ViewModels;


namespace DemoProject;

public partial class Authorisation : UserControl
{
    public Authorisation()
    {
        InitializeComponent();
        var userService = new UserService();
        DataContext = new Login_VM(userService);
    }

    private void ToRegistration(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationService.NavigateTo(new Registration());
    }
}