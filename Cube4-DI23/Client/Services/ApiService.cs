using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Client.Services
{
    public class ApiService
    {
        protected readonly HttpClient _httpClient;
        public HttpClient HttpClient
        {
            get => _httpClient;
        }

        private static readonly CookieContainer _cookieContainer = new();

        public ApiService()
        {
            var handler = new HttpClientHandler
            {
                CookieContainer = _cookieContainer
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7054/")
            };
        }

        public CookieCollection GetCookies()
        {
            return _cookieContainer.GetCookies(new Uri("https://localhost:7054/"));
        }
    }
}
