namespace BuildingBlocks.Messaging.Events.Owners
{
    public record UpdatedOwnerEvent(Guid Id, string Name) : IntegrationEvent { }
}
