namespace SpaceObserver.Worker.ISS.Services.Location
{
    using Microsoft.Extensions.Logging;

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class LocationBackgroundService : BaseBackgroundService
    {
        private readonly ILocationServiceHandler _serviceHandler;

        public LocationBackgroundService(
            ILocationServiceHandler serviceHandler,
            ILogger<LocationBackgroundService> logger) :
            base(typeof(LocationBackgroundService), logger)
        {
            _serviceHandler = serviceHandler ?? throw new ArgumentNullException(nameof(serviceHandler));
        }

        protected override async Task ExecuteAsync(CancellationToken stopToken)
        {
            try
            {
                Logger.LogInformation("Location Background Service : Executing...");

                while (!stopToken.IsCancellationRequested)
                {
                    await _serviceHandler.GetLocationAsync(stopToken);
                    await Task.Delay(50000, stopToken);
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Location Background Service: Error while getting locations");
            }
        }
    }
}