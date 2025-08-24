using Backend.Domain.Contract.DomainEvents;
using MediatR;

namespace Backend.Application.Contract.DomainEvents
{
    public class TransactionalEvent<T>(T @event) : INotification where T : IDomainEvent
    {
        public T Event { get; } = @event;
    }
}
