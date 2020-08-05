namespace SpaceObserver.Framework.Bus
{
    using Domain;
    using MediatR;
    using System.Threading.Tasks;

    public class DomainCommandDispatcher : IDomainCommandDispatcher
    {
        private readonly IMediator _mediator;

        public DomainCommandDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Dispatch(ICommand command)
        {
            await _mediator.Publish(new CommandEnvelope(command));
        }

        public void Dispose()
        {

        }
    }
}