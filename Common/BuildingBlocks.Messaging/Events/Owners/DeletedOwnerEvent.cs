namespace BuildingBlocks.Messaging.Events.Owners
{
    public record DeletedOwnerEvent(Guid Id, int Status) : IntegrationEvent { }
}
