namespace Backend.Domain.Contract.DomainEvents
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
          this.OccurredOn = DateTime.Now;
        }

        public DateTime OccurredOn { get; }
    }

}