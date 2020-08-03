using Polly;
using Polly.Extensions.Http;

namespace SpaceObserver.Worker.ISS.Extensions
{
    using Infrastructure.OpenNotify;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    using Services.Location;
    using System;

    using Utils;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSettings(this IServiceCollection services)
        {
            return services
                .AddWorkerSettings()
                .AddOpenNotifySettings();
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services
                .AddOpenNotifyServices();
        }

        public static IServiceCollection AddLocationBackgroundService(this IServiceCollection services)
        {
            services.AddSingleton<ILocationServiceHandler, LocationServiceHandler>();
            services.AddHostedService<LocationBackgroundService>();
            return services;
        }

        public static IServiceCollection AddServiceHandlers(this IServiceCollection services)
        {
            services.AddSingleton<ILocationServiceHandler, LocationServiceHandler>();
            return services;
        }

        private static IServiceCollection AddOpenNotifyServices(this IServiceCollection services)
        {
            var openNotifySettings = services.BuildServiceProvider().GetService<OpenNotifySettings>();

            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError() // HttpRequestException, 5XX and 408
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(openNotifySettings.RetryCount, retryAttempt => TimeSpan.FromSeconds(retryAttempt));

            services.AddHttpClient(openNotifySettings.Name, options =>
                {
                    options.BaseAddress = openNotifySettings.BaseUrl;
                    options.Timeout = TimeSpan.FromMilliseconds(15000);
                })
                .AddPolicyHandler(retryPolicy);

            services.AddScoped<IOpenNotifyService, OpenNotifyService>();
            return services;
        }

        private static IServiceCollection AddOpenNotifySettings(this IServiceCollection services)
        {
            var config = services.BuildServiceProvider().GetService<IConfiguration>();
            services.Configure<OpenNotifySettings>(config.GetOpenNotifySettingsConfigSection());
            services.AddSingleton(provider =>
                provider.GetRequiredService<IOptions<OpenNotifySettings>>().Value);
            return services;
        }

        private static IServiceCollection AddWorkerSettings(this IServiceCollection services)
        {
            var config = services.BuildServiceProvider().GetService<IConfiguration>();
            services.Configure<WorkerSettings>(config.GetWorkerSettingsConfigSection());
            services.AddSingleton(provider =>
                provider.GetRequiredService<IOptions<WorkerSettings>>().Value);
            return services;
        }
    }
}