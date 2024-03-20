using AutoGlass.ProductManagement.Domain.Entities;
using AutoGlass.ProductManagement.Domain.Interfaces.Repositories;
using AutoGlass.ProductManagement.Domain.Interfaces.Services;

namespace AutoGlass.ProductManagement.Domain.Services
{
    public class ServiceBase<TEntity, TSource> : IServiceBase<TEntity, TSource> where TEntity : EntityBase<TSource>
    {
        protected readonly IRepositoryBase<TEntity, TSource> _repository;

        public ServiceBase(IRepositoryBase<TEntity, TSource> repository)
        {
            _repository = repository;
        }

        public TSource Insert(TEntity entity)
        {
            return _repository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Delete(TSource id)
        {
            _repository.Delete(id);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }        
    }
}
