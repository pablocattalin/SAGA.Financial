using Backend.Application.Contract.IntegrationEvents;
using MassTransit;

namespace Backend.Persistence.Events
{
    public class MassTransitPublisherEventHandler<T> : IPublisherEventHandler<T> where T : class
    {
        private readonly IPublishEndpoint _publish;

        public MassTransitPublisherEventHandler(IPublishEndpoint publishEndpoint)
        {
            _publish = publishEndpoint;
        }


        public async Task Publish(T @event)
        {
            await _publish.Publish(@event);
        }
    }
}