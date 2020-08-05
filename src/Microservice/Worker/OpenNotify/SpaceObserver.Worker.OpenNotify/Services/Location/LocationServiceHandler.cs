namespace SpaceObserver.Worker.ISS.Services.Location
{
    using Commands;
    using Framework.Domain;
    using Infrastructure.OpenNotify;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class LocationServiceHandler : ILocationServiceHandler
    {
        private readonly ILogger<LocationServiceHandler> _logger;
        private readonly IOpenNotifyService _openNotifyService;
        private readonly IDomainCommandDispatcher _commandDispatcher;

        public LocationServiceHandler(ILogger<LocationServiceHandler> logger, 
            IOpenNotifyService openNotifyService,
            IDomainCommandDispatcher commandDispatcher)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _openNotifyService = openNotifyService ?? throw new ArgumentNullException(nameof(openNotifyService));
            _commandDispatcher = commandDispatcher ?? throw new ArgumentNullException(nameof(commandDispatcher));
        }

        public async Task GetLocationAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var payload = await _openNotifyService.GetLocationAsync().ConfigureAwait(false);
                var cmd = new CreateLocation(Guid.NewGuid(), payload);
                await _commandDispatcher.Dispatch(cmd);
            }
        }
    }
}