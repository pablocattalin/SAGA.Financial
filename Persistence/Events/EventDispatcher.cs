using Backend.Application.Contract.DomainEvents;
using Backend.Domain.Contract.DomainEvents;
using Backend.Domain.Contract.Model;
using Backend.Persistence.Database;
using MediatR;

namespace Backend.Persistence.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IMediator _mediator;
        private readonly PersistenceContext _context;

        public EventDispatcher(IMediator mediator, PersistenceContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task DispatchEventAsync()
        {

            if (_context == null) return;

            var aggregates = _context.ChangeTracker
                .Entries<IAggregateRoot>()
                .Where(a => a.Entity.GetEvents().Any())
                .Select(a => a.Entity);

            var domainEvents = aggregates
                .SelectMany(a => a.GetEvents())
                .ToList();

            aggregates.ToList().ForEach(a => a.ClearEvents());

            foreach (var domainEvent in domainEvents)
                await PublishDynamicEventAsync(domainEvent);

        }

        private async Task PublishDynamicEventAsync(IDomainEvent @event)
        {
            await this.PublishAsync((dynamic)@event);
        }

        private async Task PublishAsync<T>(T @event) where T : IDomainEvent
        {
            var transactionalEvent = new TransactionalEvent<T>(@event);

            await this._mediator.Publish(transactionalEvent)
                .ConfigureAwait(false);
        }

    }
}
