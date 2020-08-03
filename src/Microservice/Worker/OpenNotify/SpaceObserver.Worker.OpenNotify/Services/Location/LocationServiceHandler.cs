namespace SpaceObserver.Worker.ISS.Services.Location
{
    using Microsoft.Extensions.Logging;
    using Infrastructure.OpenNotify;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class LocationServiceHandler : ILocationServiceHandler
    {
        private readonly ILogger<LocationServiceHandler> _logger;
        private readonly IOpenNotifyService _openNotifyService;
//        private readonly IEventBus _eventBus;

        public LocationServiceHandler(ILogger<LocationServiceHandler> logger, IOpenNotifyService openNotifyService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _openNotifyService = openNotifyService ?? throw new ArgumentNullException(nameof(openNotifyService));
        }

        public async Task GetLocationAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Player Hosted Service: Updating...");

                while (!cancellationToken.IsCancellationRequested)
                {
                    var location = await _openNotifyService.GetIssLocationAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Player Hosted Service: Error while updating players");
            }
        }
    }
}