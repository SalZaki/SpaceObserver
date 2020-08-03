namespace SpaceObserver.Worker.ISS.Extensions
{
    using Microsoft.Extensions.Configuration;

    using Utils;

    public static class ConfigurationExtensions
    {
        public static IConfigurationSection GetWorkerSettingsConfigSection(this IConfiguration config)
        {
            return config.GetSection(Constants.Configuration.WorkerSettingsSectionName);
        }

        public static IConfigurationSection GetOpenNotifySettingsConfigSection(this IConfiguration config)
        {
            return config.GetSection(Constants.Configuration.OpenNotifySettingsSectionName);
        }
    }
}