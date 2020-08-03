namespace SpaceObserver.Worker.ISS.Utils
{
    using System;

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
    }
}