using MassTransit;

namespace Backend.Application.Contract.IntegrationEvents
{
    public interface IConsumeHandler<T> : IConsumer<T> where T : class
    {
    }
}
