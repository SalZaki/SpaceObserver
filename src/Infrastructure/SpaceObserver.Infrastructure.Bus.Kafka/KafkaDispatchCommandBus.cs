namespace SpaceObserver.Infrastructure.Bus.Kafka
{
    using Confluent.Kafka;
    using Framework.Bus;
    using Framework.Domain;

    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class KafkaDispatchCommandBus : IDispatchCommandBus
    {
        private readonly ILogger<KafkaDispatchCommandBus> _logger;
        private readonly KafkaSettings _kafkaSettings;
        private readonly ProducerConfig _producerConfig;
        private readonly ConsumerConfig _consumerConfig;

        public KafkaDispatchCommandBus(KafkaSettings kafkaSettings, ILogger<KafkaDispatchCommandBus> logger)
        {
            _kafkaSettings = kafkaSettings ?? throw new ArgumentNullException(nameof(kafkaSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            //_producerConfig = new ProducerConfigBuilder()
            //    .WithBootstrapServer(_kafkaSettings.Fqdn)
            //    .Build();

            //_consumerConfig = new ConsumerConfigBuilder()
            //    .WithBootstrapServer(_kafkaSettings.Fqdn)
            //    .WithGroupId(_kafkaSettings.ConsumerGroupId)
            //    .Build();
        }

        public Task PublishAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default, params string[] topics) where TCommand : ICommand
        {
            _logger.LogInformation(
                $"Start publishing {typeof(TCommand).Name} to topic(s) {topics}");

            _logger.LogInformation(
                $"Finish publishing {typeof(TCommand).Name} to topic(s) {topics}");

            return Task.CompletedTask;
        }

        public Task SubscribeAsync<TCommand>(CancellationToken cancellationToken = default, params string[] topics) where TCommand : ICommand, new()
        {
            return Task.CompletedTask;
        }
    }
}