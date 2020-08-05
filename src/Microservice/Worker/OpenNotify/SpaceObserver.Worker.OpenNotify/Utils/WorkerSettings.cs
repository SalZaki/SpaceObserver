namespace SpaceObserver.Worker.ISS.Utils
{
    using System;
    using System.Collections.Generic;

    internal sealed class WorkerSettings
    {
        public string Name { get; set; }

        public string ServiceDocumentationUrl { get; set; }

        public string Description { get; set; }

        public string ContactName { get; set; }

        public string ContactEmail { get; set; }

        public Uri TermOfServiceUrl { get; set; }

        public string LicenseName { get; set; }

        public Uri LicenseUrl { get; set; }

        public IEnumerable<KafkaTopic> KafkaTopics { get; set; }
    }

    internal class KafkaTopic
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string CommandType { get; set; }
    }
}