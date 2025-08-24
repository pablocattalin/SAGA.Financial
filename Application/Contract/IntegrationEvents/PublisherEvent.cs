using BuildingBlocks.Messaging.Events;

namespace Backend.Application.Contract.IntegrationEvents
{
    public class PublisherEvent<T> where T : IntegrationEvent
    {
        public T Event { get; }
        public PublisherEvent(T @event)
        {
            Event = @event;
        }

    }
}
