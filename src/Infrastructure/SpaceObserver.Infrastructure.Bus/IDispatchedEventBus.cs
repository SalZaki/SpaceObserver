﻿namespace SpaceObserver.Infrastructure.Bus
{
    using System.Threading.Tasks;
    using Google.Protobuf;

    public interface IDispatchedEventBus
    {
        Task PublishAsync<TMessage>(TMessage msg, params string[] channels) where TMessage : IMessage<TMessage>;

        Task SubscribeAsync<TMessage>(params string[] channels) where TMessage : IMessage<TMessage>, new();
    }
}