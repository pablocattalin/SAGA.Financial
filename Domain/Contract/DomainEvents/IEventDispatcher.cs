namespace Backend.Domain.Contract.DomainEvents
{
    public interface IEventDispatcher
    {
        Task DispatchEventAsync();
    }
}
