using Avalonia.Controls;
using DemoProject.Classes;

namespace DemoProject.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NavigationService.Initialize(frame);
            NavigationService.NavigateTo(new Registration());
            fdsfsdf
        }
    }
}