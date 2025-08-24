namespace BuildingBlocks.Messaging.Events.FinancialAccounts
{
    public record DeletedFinancialAccountEvent(Guid? VoucherId,
        Guid? PaymentId,
        Guid OwnerId);
}
