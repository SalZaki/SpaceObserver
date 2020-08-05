using System.Linq;

namespace SpaceObserver.Worker.ISS.CommandPublishers
{
    using Commands;
    using Framework.Bus;

    using MediatR;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Utils;

    internal class KafkaCommandPublisher : INotificationHandler<CommandEnvelope>
    {
        private readonly IDispatchCommandBus _dispatchCommandBus;
        private readonly WorkerSettings _workerSettings;
        private readonly ILogger<KafkaCommandPublisher> _logger;

        public KafkaCommandPublisher(IDispatchCommandBus dispatchCommandBus,
            WorkerSettings workerSettings,
            ILogger<KafkaCommandPublisher> logger)
        {
            _dispatchCommandBus = dispatchCommandBus ?? throw new ArgumentNullException(nameof(dispatchCommandBus));
            _workerSettings = workerSettings ?? throw new ArgumentNullException(nameof(workerSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(CommandEnvelope commandEnvelope, CancellationToken cancellationToken = default)
        {
            switch (commandEnvelope.Command)
            {
                case CreateLocation _:
                    var topics = GetActiveKafkaTopics($"{typeof(CreateLocation).Name}");
                    await _dispatchCommandBus.PublishAsync(commandEnvelope.Command, cancellationToken, "");
                    break;
            }
        }

        private string[] GetActiveKafkaTopics(string commandType)
        {
            return _workerSettings.KafkaTopics?
                .Where(x => x.IsActive == true && x.CommandType == commandType)
                .Select(x => x.Name)
                .ToArray();
        }
    }
}