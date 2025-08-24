namespace BuildingBlocks.Messaging.Events.Vouchers
{
    public record MovementedStockVoucherEvent(Guid OwnerId,
                                      decimal Total,
                                      Guid VoucherId,
                                      int VoucherType,
                                      string VoucherNumber,
                                      DateTime VoucherDate,
                                      List<MovementedStockVoucherItemEvent> Items) : IntegrationEvent;

    public record MovementedStockVoucherItemEvent(
        Guid VoucherId,
        Guid ItemId,
        Guid ProductId,        
        double Quantity);
}
