using Backend.Application.Contract.Persistence;
using Backend.Domain.Contract.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Backend.Persistence.Database
{
    internal class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly PersistenceContext _context;

        public Repository(PersistenceContext context)
        {
            _context = context;
        }

        public void BulkDelete(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task BulkInsert(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<T> GetAll()
        {

            return _context.Set<T>()
                                .AsQueryable();
        }

        public async Task<T> GetById(Identity id)
        {
            return await _context.Set<T>().FindAsync((dynamic)id);
        }

        public async Task Insert(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                                .ToListAsync();
        }
    }
}
