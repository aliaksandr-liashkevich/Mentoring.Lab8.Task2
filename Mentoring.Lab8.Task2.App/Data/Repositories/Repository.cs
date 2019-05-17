using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mentoring.Lab8.Task2.App.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly NorthwindDbContext DbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(NorthwindDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = DbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await _dbSet.CountAsync(predicate);
            }
            return await _dbSet.CountAsync();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id).ConfigureAwait(false);
        }

        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate, int skip, int take)
        {
            return _dbSet.Where(predicate).Skip(skip).Take(take);
        }

        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<TEntity> GetMany()
        {
            return _dbSet;
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}