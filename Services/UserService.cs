using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using HakatonServer.Controllers;

namespace DemoProject.Services
{
    public class UserService : ApiBase
    {
        public record LoginRequest
        {
            public string Email {  get; set; }
            public string Password { get; set; }
        }
        public record RegisterRequest
        {
            public string? Name { get; set; }
            public string? Lastname { get; set; }
            public string? Patronymic { get; set; }
            public string? Phone { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
        }
        public record AuthResponse
        {
            public string Token { get; set; }
        }
        public async Task<string?> Login(string email, string password)
        {
            var request = new LoginRequest
            {
                Email = email,
                Password = password
            };
            var response = await Http.PostAsJsonAsync("user/login", request);
            if(response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
                return authResponse?.Token;
            } else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Ошибка входа: {error}");
            }
        }

        public async Task<string?> Register(string name, string lastname, string patronymic, string phone, string email, string password)
        {
            var request = new RegisterRequest
            {
                Name = name,
                Lastname = lastname,
                Patronymic = patronymic,
                Phone = phone,
                Email = email,
                Password = password
            };
            var response = await Http.PostAsJsonAsync("user/create", request);
            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
                return authResponse?.Token;
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Ошибка входа: {error}");
            }
        }
    }
}
