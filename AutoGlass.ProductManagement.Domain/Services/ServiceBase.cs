using AutoGlass.ProductManagement.Domain.Entities;
using AutoGlass.ProductManagement.Domain.Interfaces.Repositories;
using AutoGlass.ProductManagement.Domain.Interfaces.Services;
using System.Linq.Expressions;

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

        public bool Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(TSource id)
        {
            return _repository.Delete(id);
        }

        public bool Delete(TEntity entity)
        {
            return _repository.Delete(entity);
        }

        public TEntity GetById(TSource id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> FindByProperty(Expression<Func<TEntity, bool>> filterExpression)
        {
            return _repository.FindByProperty(filterExpression);
        }
    }
}
