namespace Backend.Domain.Contract.DomainEvents
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
