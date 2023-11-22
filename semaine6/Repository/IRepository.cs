using System.Linq.Expressions;

namespace semaine6.Repository
{
    public interface IRepository<T>
    {
        Task InsertAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IList<T>> SearchForAsync(Expression<Func<T, bool>> predicate);
        Task<bool?> SaveAsync(T entity);
        Task<bool?> SaveAsync(T entity, Expression<Func<T, bool>> predicate);
        Task<IList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
    }
}
