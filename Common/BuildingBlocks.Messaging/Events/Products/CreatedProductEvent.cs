namespace BuildingBlocks.Messaging.Events.Products
{
    public record CreatedProductEvent(Guid Id,
                                      string Name,
                                      string Description,
                                      decimal Price,
                                      string CategoryId) : IntegrationEvent
    { }
}
