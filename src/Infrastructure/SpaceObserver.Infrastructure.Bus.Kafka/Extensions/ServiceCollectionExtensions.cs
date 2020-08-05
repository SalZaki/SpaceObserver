namespace SpaceObserver.Infrastructure.Bus.Kafka.Extensions
{
    using Framework.Bus;
    using Framework.Extensions;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddKafkaCommandBus(this IServiceCollection services)
        {
            services.AddSingleton<IDispatchCommandBus, KafkaDispatchCommandBus>();
            return services;
        }

        public static IServiceCollection AddKafkaSettings(this IServiceCollection services)
        {
            var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<KafkaSettings>(config.GetKafkaSettingsConfigSection());
            services.AddSingleton(provider =>
                provider.GetRequiredService<IOptions<KafkaSettings>>().Value);
            return services;
        }
    }
}