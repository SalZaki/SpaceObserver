namespace SpaceObserver.Framework.Domain
{
    using System;

    public abstract class CommandBase : ICommand
    {
        public Guid Id { get; protected set; }

        public string Payload { get; protected set; }

        public int CommandVersion { get; protected set; } = 1;

        public DateTime CreatedOn { get; protected set; }
    }
}