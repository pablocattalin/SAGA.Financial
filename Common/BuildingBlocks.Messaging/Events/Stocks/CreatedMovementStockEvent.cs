namespace BuildingBlocks.Messaging.Events.Stocks
{
    public record CreatedMovementStockEvent(Guid VoucherId,                                      
                                      Guid InventoryDocumentId,                                      
                                      string VoucherNumber,
                                      DateTime VoucherDate,
                                      List<CreatedMovementStockItemsEvent> Items) : IntegrationEvent;  

    public record CreatedMovementStockItemsEvent(Guid InventoryDocumentItemId,
                                      double Quantity);
}
