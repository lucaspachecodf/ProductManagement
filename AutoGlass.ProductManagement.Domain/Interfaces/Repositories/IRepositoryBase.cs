using AutoGlass.ProductManagement.Domain.Entities;
using System.Linq.Expressions;

namespace AutoGlass.ProductManagement.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity, TSource> where TEntity : EntityBase<TSource>
    {
        TSource Insert(TEntity entity);
        bool Delete(TEntity entity);
        bool Delete(TSource id);
        bool Update(TEntity entity);
        void Save();
        Task SaveAsync();
        bool Any(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeExpressions);
        TEntity GetById(TSource ID, params Expression<Func<TEntity, object>>[] includeExpressions);
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions);
        TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
                                           Expression<Func<TEntity, bool>> predicate = null,
                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                           bool disableTracking = true);

        IEnumerable<TEntity> FindByProperty(Expression<Func<TEntity, bool>> filterExpression);
    }
}
