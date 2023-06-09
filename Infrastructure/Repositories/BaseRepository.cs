using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
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
                Data = data.AsQueryable()
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


    }
}