using Backend.Domain.Contract.Model;
using System.Linq.Expressions;

namespace Backend.Application.Contract.Persistence
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync();
        Task<T> GetById(Identity id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter);
        Task Insert(T entity);
        void Delete(T entity);
        Task BulkInsert(List<T> entities);
        void BulkDelete(List<T> entities);
    }
}
