using Backend.Domain.Contract.DomainEvents;
using MediatR;

namespace Backend.Application.Contract.DomainEvents
{
    interface INotificationEventHandler<T> : INotificationHandler<NotificationEvent<T>> where T : IDomainEvent
    {
    }
}
