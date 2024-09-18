using Microsoft.Extensions.Configuration;

namespace bleaf_test_automation.Utils
{
    public static class ConfigManager
    {
        private static IConfigurationRoot _configuration;

        static ConfigManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public static string GetConfigValue(string key)
        {
            return _configuration[key];
        }
    }
}