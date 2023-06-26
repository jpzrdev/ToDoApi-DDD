using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.Pagination;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ToDoApiContext _dbContext;
        public BaseRepository(ToDoApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            ExcludeDeleted(ref query);
            IncludeProperties(ref query, includes);

            return await query.ToListAsync();
        }

        public virtual async Task<PaginatedData<T>> GetAllPaginatedAsync(int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);


            ExcludeDeleted(ref query);
            IncludeProperties(ref query, includes);


            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedData<T>
            {
                TotalPages = totalPages,
                TotalCount = totalCount,
                Page = pageNumber,
                PageSize = pageSize,
                Data = data
            };
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        protected void IncludeProperties(ref IQueryable<T> query, params Expression<Func<T, object>>[] properties)
        {
            foreach (var includeProperty in properties)
            {
                query = query.Include(includeProperty);
            }
        }
        protected void ExcludeDeleted(ref IQueryable<T> query)
        {
            // Adicione a condição para excluir os registros com Deleted = true
            var deletedProperty = typeof(T).GetProperty("Deleted");
            if (deletedProperty != null && deletedProperty.PropertyType == typeof(bool))
            {
                var parameter = Expression.Parameter(typeof(T), "e");
                var deletedExpression = Expression.Property(parameter, deletedProperty);
                var condition = Expression.Equal(deletedExpression, Expression.Constant(false));
                var lambda = Expression.Lambda<Func<T, bool>>(condition, parameter);
                query = query.Where(lambda);
            }
        }
        public async Task<T> Find(Expression<Func<T, bool>> filterExpression, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (filterExpression is not null)
                query = query.Where(filterExpression);

            ExcludeDeleted(ref query);
            IncludeProperties(ref query, includes);

            return query.SingleOrDefault();
        }
    }
}