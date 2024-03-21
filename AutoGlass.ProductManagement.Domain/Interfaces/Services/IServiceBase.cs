using AutoGlass.ProductManagement.Domain.Entities;
using System.Linq.Expressions;

namespace AutoGlass.ProductManagement.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity, TSource> where TEntity : EntityBase<TSource>
    {
        TSource Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TSource id);
        bool Delete(TEntity entity);
        TEntity GetById(TSource id);        
        IEnumerable<TEntity> FindByProperty(Expression<Func<TEntity, bool>> filterExpression);
    }
}
