using Backend.Domain.Contract.DomainEvents;

namespace Backend.Domain.Contract.Model
{
    public class AggregateRoot<T> : Entity<T>, IAggregateRoot where T : new()
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public IEnumerable<IDomainEvent> GetEvents()
        {
            return _domainEvents;
        }

        public IDomainEvent[] ClearEvents()
        {
            IDomainEvent[] dequeuedEvents = [.. _domainEvents];

            _domainEvents.Clear();

            return dequeuedEvents;
        }

        public void AddEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }
    }
}
