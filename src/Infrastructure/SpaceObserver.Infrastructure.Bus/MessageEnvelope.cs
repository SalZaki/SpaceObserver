namespace SpaceObserver.Infrastructure.Bus
{
    using Google.Protobuf;
    using MediatR;

    public class MessageEnvelope<T> : INotification
        where T : IMessage<T>
    {
        public MessageEnvelope(IMessage<T> message)
        {
            Message = message;
        }

        public IMessage<T> Message { get; }
    }
}