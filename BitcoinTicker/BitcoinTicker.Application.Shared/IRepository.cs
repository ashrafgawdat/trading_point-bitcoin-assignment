using BitcoinTicker.Core;
using System.Linq.Expressions;

namespace BitcoinTicker.Application.Shared
{
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : EntityBase<int>
    {

    }
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : EntityBase<TPrimaryKey>
    {
        Task<TEntity> GetAsync(TPrimaryKey id);
        Task<TEntity> FirstOrDefaultAsync();
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllListAsync();
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);
        Task InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(TPrimaryKey id);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TPrimaryKey> CountAsync();
        Task<TPrimaryKey> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task SaveChangesAsync();
    }
}
