namespace BuildingBlocks.Messaging.Events.Owners
{
    public record CreatedOwnerEvent(Guid Id, string Name, int Status, string OwnerType) // : IntegrationEvent
    {
    }
}
