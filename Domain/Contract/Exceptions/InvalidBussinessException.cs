namespace Backend.Domain.Contract.Exceptions
{
    public class InvalidBussinessException: Exception
    {
        public ErrorCode? ErrorCode { get; }

        public InvalidBussinessException(string message, ErrorCode? errorCode = null) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
