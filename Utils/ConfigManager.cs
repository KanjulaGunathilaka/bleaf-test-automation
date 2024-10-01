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
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public static string GetConfigValue(string key)
        {
            string value = _configuration[key];
            Console.WriteLine($"Config value for '{key}': {value}");
            return value;
        }
    }
}