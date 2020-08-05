namespace SpaceObserver.Framework.Domain
{
    using System;
    using System.Threading.Tasks;

    public interface IDomainCommandDispatcher : IDisposable
    {
        Task Dispatch(ICommand command);
    }
}