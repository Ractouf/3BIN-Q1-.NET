using Microsoft.EntityFrameworkCore;
using semaine6.Models;
using System.Linq.Expressions;

namespace semaine6.Repository
{
    public class BaseRepositorySQL<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly NorthwindContext _dbContext;
        public BaseRepositorySQL(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);

            await SaveChangesAsync();
        }

        public async Task<bool?> SaveAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            TEntity? ent = (await SearchForAsync(predicate)).FirstOrDefault();

            if (ent == null)
            {
                await InsertAsync(entity);
                return true;
            }
            else
            {
                _dbContext.Set<TEntity>().Update(entity);
                await SaveChangesAsync();
            }

            return true;

        }

        public async Task<bool?> SaveAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await SaveChangesAsync();
            return true;
        }

        public async Task<IList<TEntity>> SearchForAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        protected async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.InnerException.Message);
            }
        }
    }
}
