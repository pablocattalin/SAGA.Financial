using Backend.Application.Contract.Persistence;
using MediatR;

namespace Backend.Persistence.Processing
{
    public class CommandHandlerDecorator<T, U> : IRequestHandler<T, U> where T : IRequest<U>
    {
        private readonly IRequestHandler<T, U> _handler;
        private readonly IUnitOfWork _uow;

        public CommandHandlerDecorator(IRequestHandler<T, U> handler, IUnitOfWork uow)
        {
            _handler = handler;
            _uow = uow;
        }

        public async Task<U> Handle(T request, CancellationToken cancellationToken)
        {
            var result = await this._handler.Handle(request, cancellationToken);

            await _uow.CommitAsync(cancellationToken);

            return result;
        }
    }

    public class CommandHandlerDecorator<T> : IRequestHandler<T> where T : IRequest
    {
        private readonly IRequestHandler<T> _handler;
        private readonly IUnitOfWork _uow;

        public CommandHandlerDecorator(IRequestHandler<T> handler, IUnitOfWork uow)
        {
            _handler = handler;
            _uow = uow;
        }

        public async Task Handle(T request, CancellationToken cancellationToken)
        {
            await this._handler.Handle(request, cancellationToken);

            await _uow.CommitAsync(cancellationToken);            
        }
    }
}
