using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Services
{
    public class NewsService : ApiBase
    {
        public async Task<List<Models.News>> GetNewsAsync()
        {

            var response = await Http.GetAsync("news");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<Models.News>>() ?? new();

            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Ошибка загрузки новостей: {error}");
        }
    }
}
