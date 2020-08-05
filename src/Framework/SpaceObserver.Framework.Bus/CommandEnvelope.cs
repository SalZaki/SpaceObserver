namespace SpaceObserver.Framework.Bus
{
    using MediatR;
    using Domain;

    /// <summary>
    /// This class contains the domain command which published from domain entity.
    /// We use DomainEventBus to handle and publish it back to the specific project,
    /// then it will handle and use some of popular message brokers like Redis/Kafka to handle it
    /// </summary>
    public class CommandEnvelope : INotification
    {
        public CommandEnvelope(ICommand command)
        {
            Command = command;
        }

        public ICommand Command { get; }
    }
}