using MassTransit;

namespace Backend.Application.Contract.IntegrationEvents
{
    public interface IConsumeHandlerDecorator<T> : IFilter<ConsumeContext<T>> where T : class
    {

    }
}
