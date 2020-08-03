//namespace SpaceObserver.Infrastructure.Bus
//{
//    using MediatR;
//    using System.Threading.Tasks;

//    public class DomainEventDispatcher : IDomainEventDispatcher
//    {
//        private readonly IMediator _mediator;

//        public DomainEventDispatcher(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        public async Task Dispatch(IEvent @event)
//        {
//            await _mediator.Publish(new NotificationEnvelope(@event));
//        }

//        public void Dispose()
//        {
//        }
//    }
//}