namespace SpaceObserver.Framework.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Utils;

    public static class ConfigurationExtensions
    {
        public static IConfigurationSection GetApiSettingsConfigSection(this IConfiguration config)
        {
            return config.GetSection(Constants.Configuration.ApiSettingsSection);
        }
    }
}