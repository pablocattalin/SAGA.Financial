namespace Backend.Application.Contract.IntegrationEvents
{
    public interface IPublisherEventHandler<T> where T : class
    {
        Task Publish(T @event);
    }

}
