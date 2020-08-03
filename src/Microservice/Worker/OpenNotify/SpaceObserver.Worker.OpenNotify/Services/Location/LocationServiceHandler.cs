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
        // private readonly IEventBus _eventBus;

        public LocationServiceHandler(ILogger<LocationServiceHandler> logger, IOpenNotifyService openNotifyService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _openNotifyService = openNotifyService ?? throw new ArgumentNullException(nameof(openNotifyService));
        }

        public async Task GetLocationAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var location = await _openNotifyService.GetIssLocationAsync().ConfigureAwait(false);
                //_eventBus.Publish(location);
            }
        }
    }
}