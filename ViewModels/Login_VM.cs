using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoProject.Classes;
using DemoProject.Services;
using HakatonServer.Auth;
using MsBox.Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.Views;


namespace DemoProject.ViewModels
{
    public partial class Login_VM : ObservableObject
    {
        private readonly UserService _userService;
        public Login_VM(UserService userService)
        {
            _userService = userService;
        }
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private string _errorMessage;
        [ObservableProperty]
        private bool _isLoading;

        [RelayCommand]
        private async Task LoginAsync()
        {
            IsLoading = true;
            ErrorMessage = string.Empty;

            try
            {
                var token = await _userService.Login(Email, Password);
                NavigationService.NavigateTo(new News());
            }
            catch (Exception ex)
            {
                await MessageBoxManager.GetMessageBoxStandard("Заголовок", $"{ex.Message}").ShowAsync();
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
