namespace BuildingBlocks.Messaging.Events.Vouchers
{
    public record CreatedVoucherEvent(Guid OwnerId,
                                      decimal Total,
                                      Guid VoucherId,
                                      bool IsSale) : IntegrationEvent;    
}
