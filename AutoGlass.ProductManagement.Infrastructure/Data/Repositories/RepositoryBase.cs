using AutoGlass.ProductManagement.Context;
using AutoGlass.ProductManagement.Domain.Entities;
using AutoGlass.ProductManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutoGlass.ProductManagement.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity, TSource> : IDisposable, IRepositoryBase<TEntity, TSource> where TEntity : EntityBase<TSource>
    {
        public RepositoryBase(ProductManagementDataContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (!_dispose)
            {
                if (dispose)
                {
                    _context.Dispose();
                }
            }

            _dispose = true;
        }

        public TSource Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            Save();

            return entity.Id;
        }

        public bool Delete(TSource id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                return Delete(entity);
            }

            return false;
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _context.Update(entity);
                Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Save() => _context.SaveChanges();
        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public bool Any(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            IQueryable<TEntity> set;

            if (includeExpressions.Any())
            {
                set = includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                    (_dbSet, (current, expression) => current.Include(expression));
            }
            else
                set = _context.Set<TEntity>();

            return set.Any(predicate);
        }

        public TEntity GetById(TSource ID, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                    (_dbSet, (current, expression) => current.Include(expression));

                return set.SingleOrDefault(s => s.Id.Equals(ID));
            }

            return _context.Set<TEntity>().Find(ID);
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            return includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
               (_dbSet, (current, expression) => current.Include(expression));
        }

        public IEnumerable<TEntity> FindByProperty(Expression<Func<TEntity, bool>> filterExpression)
        {
            return _dbSet.Where(filterExpression.Compile());
        }

        public TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
                query = query.AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).Select(selector).FirstOrDefault();
            else
                return query.Select(selector).FirstOrDefault();
        }

        protected readonly ProductManagementDataContext _context;
        private DbSet<TEntity> _dbSet;
        private bool _dispose = false;
    }
}
