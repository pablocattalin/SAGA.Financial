using Backend.Domain.Contract.DomainEvents;
using MediatR;

namespace Backend.Application.Contract.DomainEvents
{
    public interface ITransactionalEventHandler<T> : INotificationHandler<TransactionalEvent<T>> where T : IDomainEvent
    {
    }
}
