namespace SpaceObserver.Framework.Bus
{
    using Domain;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDispatchCommandBus
    {
        Task PublishAsync<TCommand>(TCommand @command, CancellationToken cancellationToken = default, params string[] topics) where TCommand : ICommand;
        
        Task SubscribeAsync<TCommand>(CancellationToken cancellationToken = default, params string[] topics) where TCommand : ICommand, new();
    }
}