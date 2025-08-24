namespace BuildingBlocks.Messaging.Events.FinancialAccounts
{
    public record UpdatedFinancialAccountEvent(Guid? VoucherId,
        Guid? PaymentId,
        decimal Credit,
        decimal Debit,
        Guid OwnerId,
        string VoucherNumber,
        DateTime VoucherDate);
}
