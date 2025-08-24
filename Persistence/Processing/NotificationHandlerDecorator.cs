using Backend.Domain.Contract.DomainEvents;
using MediatR;

namespace Backend.Persistence.Processing
{
    public class NotificationHandlerDecorator<T> : INotificationHandler<T> where T : INotification
    {
        private readonly INotificationHandler<T> _handler;
        private readonly IEventDispatcher _eventDispatcher;

        public NotificationHandlerDecorator(INotificationHandler<T> handler, IEventDispatcher eventDispatcher)
        {
            this._handler = handler;
            this._eventDispatcher = eventDispatcher;
        }

        public async Task Handle(T notification, CancellationToken cancellationToken)
        {
            await this._handler.Handle(notification, cancellationToken);

            await this._eventDispatcher.DispatchEventAsync();
        }
    }
}
