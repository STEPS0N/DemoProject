using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Services
{
    public abstract class ApiBase
    {
        protected readonly HttpClient Http;
        protected ApiBase()
        {
            Http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7088/api/")
            };
        }
    }
}
