using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mentoring.Lab8.Task2.App.Data.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task<TEntity> GetByIdAsync(object id);
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate, int skip, int take);
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetMany();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
