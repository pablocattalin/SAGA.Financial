namespace BuildingBlocks.Messaging.Events.Products
{
    public record DeletedProductEvent : IntegrationEvent
    {
        public string Id { get; private set; }
        public DeletedProductEvent(string id)
        {
            Id = id;
        }
    }
}
