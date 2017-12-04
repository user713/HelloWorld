using System;
using System.Net.Http;

namespace ConsoleApp1
{
    /// <summary>
    /// Returns messages from a web service.
    /// </summary>
    public class WebApiMessageRepository : IMessageRepository
    {
        private readonly IWebApiSettings _settings;

        public WebApiMessageRepository(IWebApiSettings settings)
        {
            _settings = settings;
        }

        public string GetMessage()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_settings.BaseUrl);
                var response = client.GetAsync("api/messages").Result;
                response.EnsureSuccessStatusCode();
                var message = response.Content.ReadAsStringAsync().Result;
                return message;
            }
        }
    }
}