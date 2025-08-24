using Backend.Application.Contract.IntegrationEvents;
using Backend.Application.Contract.Persistence;
using MassTransit;

namespace Backend.Persistence.Processing
{
    public class ConsumeHandlerDecorator<T>: IConsumeHandlerDecorator<T> where T: class
    {        
        private readonly IUnitOfWork _uow;        

        public ConsumeHandlerDecorator(IUnitOfWork uow)
        {            
            _uow = uow;
        }

        public void Probe(ProbeContext context) => context.CreateFilterScope("ConsumeHandlerDecorator");

        public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
        {
            await next.Send(context);

            await _uow.CommitAsync();
        }
    }    

}
