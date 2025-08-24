using Backend.Application.Contract.Persistence;
using Backend.Domain.Contract.DomainEvents;
using Backend.Persistence.Database;

namespace Backend.Persistence.Processing
{
    public class UnitOfWork(PersistenceContext context, IEventDispatcher eventDispatcher) : IUnitOfWork
    {
        private readonly PersistenceContext _context = context;
        private readonly IEventDispatcher _eventDispatcher = eventDispatcher;

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            await this._eventDispatcher.DispatchEventAsync();
            return await this._context.SaveChangesAsync(cancellationToken);
        }
    }

}
