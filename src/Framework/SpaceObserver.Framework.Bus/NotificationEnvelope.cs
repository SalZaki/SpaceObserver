namespace SpaceObserver.Framework.Bus
{
    using Domain;
    using MediatR;

    public class NotificationEnvelope : INotification
    {
        public NotificationEnvelope(ICommand command)
        {
            Command = command;
        }

        public ICommand Command { get; }
    }
}