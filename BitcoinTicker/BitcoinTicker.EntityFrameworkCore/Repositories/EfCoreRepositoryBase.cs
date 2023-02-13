using BitcoinTicker.Application.Shared;
using BitcoinTicker.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinTicker.EntityFrameworkCore.Repositories
{
    public abstract class EfCoreRepositoryBase<TDbContext, TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TDbContext : DbContext where TEntity : EntityBase<TPrimaryKey>
    {
        protected readonly TDbContext _dbContext;

        public EfCoreRepositoryBase(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await GetAll().FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<TEntity> FirstOrDefaultAsync()
        {
            return await GetAll().FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().FirstOrDefaultAsync(predicate);
        }
                
        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll()
                        .Where(predicate)
                        .ToListAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            IQueryable<TEntity> queryable = GetAll();
            if (!propertySelectors.IsNullOrEmpty())
            {
                foreach (Expression<Func<TEntity, object>> navigationPropertyPath in propertySelectors)
                {
                    queryable = queryable.Include(navigationPropertyPath);
                }
            }

            return queryable;
        }

        public async Task InsertAsync(TEntity entity)
        {
            entity.CreationDate = DateTime.Now;
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task<TPrimaryKey> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TPrimaryKey> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
