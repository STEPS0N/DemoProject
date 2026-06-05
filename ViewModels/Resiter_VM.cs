using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.Services;
using CommunityToolkit.Mvvm.Input;
using DemoProject.Classes;
using HakatonServer.Auth;
using MsBox.Avalonia;

namespace DemoProject.ViewModels
{
    public partial class Resiter_VM : ObservableObject
    {
        private readonly UserService _userService;
        public Resiter_VM(UserService userService)
        {
            _userService = userService;
        }
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _lastname;
        [ObservableProperty]
        private string _patronymic;
        [ObservableProperty]
        private string _phone;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private bool _isLoading;

        [RelayCommand]
        private async Task RegisterAsync()
        {
            IsLoading = true;

            try
            {
                var token = await _userService.Register(Name, Lastname, Patronymic, Phone, Email, Password);
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
