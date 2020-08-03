namespace SpaceObserver.Worker.ISS
{
    using Extensions;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    using Serilog;
    using System.IO;
    using System.Threading.Tasks;

    using Utils;

    public class Program
    {
        private const string Prefix = "SPACEOBSERVER_";

        public static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);

            var host = hostBuilder.Build();

            var serviceScopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                var settings = scope.ServiceProvider.GetRequiredService<WorkerSettings>();
                var hostEnvironment = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
                logger.LogInformation("-----------------------------------------------------------------------");
                logger.LogInformation($"Name: {settings.Name}");
                logger.LogInformation($"Description: {settings.Description}");
                logger.LogInformation($"Contact Name: {settings.ContactName}");
                logger.LogInformation($"Contact Email: {settings.ContactEmail}");
                logger.LogInformation($"License: {settings.LicenseName}");
                logger.LogInformation($"Environment: {hostEnvironment.EnvironmentName}");
                logger.LogInformation("-----------------------------------------------------------------------");
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = new HostBuilder()

                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddCommandLine(args);
                    configHost.AddEnvironmentVariables(prefix: Prefix);
                })

                .ConfigureAppConfiguration((context, configBuilder) =>
                {
                    configBuilder.SetBasePath(Directory.GetCurrentDirectory());
                    configBuilder.AddCommandLine(args);
                    configBuilder.AddEnvironmentVariables(prefix: Prefix);
                    configBuilder.AddJsonFile("appsettings.json", false);
                    configBuilder.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", true);
                })

                .ConfigureServices(services =>
                {
                    services.AddSettings();
                    services.AddServiceHandlers();
                    services.AddInfrastructureServices();
                    services.AddLocationBackgroundService();
                })

                .UseSerilog((hostContext, loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration);
                });

            return hostBuilder;
        }
    }
}