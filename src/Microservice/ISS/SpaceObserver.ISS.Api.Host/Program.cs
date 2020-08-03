namespace SpaceObserver.ISS.Api.Host
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Serilog;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hi, it's SpaceObserver ISS Api ... standing by");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.ConfigureAppConfiguration(SetupConfiguration);
                        webBuilder.UseSerilog((hostContext, loggerConfiguration) =>
                            loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration));
                    }
                );

        private static void SetupConfiguration(WebHostBuilderContext hostingContext,
            IConfigurationBuilder configBuilder)
        {
            var environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            if (string.IsNullOrWhiteSpace(environmentName))
            {
                environmentName = "Production";
            }

            configBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables("EssentialDotNetConfiguration")
                .Build();
        }
    }
}