namespace SpaceObserver.Worker.ISS.Commands
{
    using System;
    using Framework.Domain;

    public sealed class CreateLocation : CommandBase
    {
        public CreateLocation(Guid id, string payload)
        {
            Id = id;
            Payload = payload;
        }
    }
}