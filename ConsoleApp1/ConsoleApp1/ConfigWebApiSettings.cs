using Microsoft.Extensions.Configuration;

namespace ConsoleApp1
{
    public class ConfigWebApiSettings : IWebApiSettings
    {
        public string BaseUrl { get; }

        public ConfigWebApiSettings(IConfigurationRoot configurationRoot)
        {
            var section = configurationRoot.GetSection("WebApiSettings");

            BaseUrl = section[nameof(BaseUrl)];
        }
    }
}