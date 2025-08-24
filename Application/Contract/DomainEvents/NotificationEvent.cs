using Backend.Domain.Contract.DomainEvents;
using MediatR;

namespace Backend.Application.Contract.DomainEvents
{
    class NotificationEvent<T>(T @event) : INotification where T : IDomainEvent
    {
        public T Event { get; } = @event;
    }

}