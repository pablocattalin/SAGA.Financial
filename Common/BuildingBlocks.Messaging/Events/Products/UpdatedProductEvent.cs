namespace BuildingBlocks.Messaging.Events.Products
{
    public record UpdatedProductEvent(Guid Id,
                                      string Name,
                                      string Description,
                                      decimal UnitPrice,
                                      string CategoryId) : IntegrationEvent
    { }
}
