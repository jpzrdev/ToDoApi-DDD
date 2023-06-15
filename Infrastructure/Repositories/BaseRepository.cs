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

            IncludeProperties(ref query, properties);

            return await query.ToListAsync();
        }

        public virtual async Task<PaginatedData<T>> GetAllPaginatedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _dbContext.Set<T>().CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var data = await _dbContext.Set<T>()
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

        public async Task<T> Find(Expression<Func<T, bool>> filterExpression, params Expression<Func<T, object>>[] properties)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (filterExpression is not null)
                query = query.Where(filterExpression);

            if (properties is not null)
                IncludeProperties(ref query, properties);

            return query.SingleOrDefault();
        }
    }
}