namespace SpaceObserver.Infrastructure.Bus.Kafka
{
    public sealed class KafkaSettings
    {
        public string FQDN { get; set; }

        public int MaxRetries { get; set; }

        public int MessageTimeout { get; set; }

        public string ConsumerGroupId { get; set; }

        public long SubscriptionPollIntervalMs { get; set; }

        public string Name { get; set; }
    }
}