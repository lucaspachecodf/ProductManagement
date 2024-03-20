using AutoGlass.ProductManagement.Domain.Entities;

namespace AutoGlass.ProductManagement.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity, TSource> where TEntity : EntityBase<TSource>
    {
        TSource Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TSource id);
        void Delete(TEntity entity);
    }
}
