namespace SpaceObserver.Worker.ISS.Infrastructure.OpenNotify
{
    using System;

    internal sealed class OpenNotifySettings
    {
        public string Name { get; set; }

        public Uri BaseUrl { get; set; }

        public string IssLocationEndpoint { get; set; }

        public int RetryCount { get; set; }
    }
}