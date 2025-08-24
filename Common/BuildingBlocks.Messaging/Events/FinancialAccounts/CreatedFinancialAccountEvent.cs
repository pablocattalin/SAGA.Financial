namespace BuildingBlocks.Messaging.Events.FinancialAccounts
{
    public record CreatedFinancialAccountEvent(Guid? VoucherId,
        Guid? PaymentId,
        decimal Credit,
        decimal Debit,        
        Guid OwnerId,
        string VoucherNumber,
        DateTime VoucherDate);
}
