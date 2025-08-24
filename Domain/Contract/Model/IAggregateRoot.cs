using Backend.Domain.Contract.DomainEvents;

namespace Backend.Domain.Contract.Model
{
    public interface IAggregateRoot
    {
        IEnumerable<IDomainEvent> GetEvents();
        IDomainEvent[] ClearEvents();
        void AddEvent(IDomainEvent @event);
    }
}
