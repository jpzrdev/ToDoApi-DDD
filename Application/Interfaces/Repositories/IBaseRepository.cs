using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Pagination;

namespace Application.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<PaginatedData<T>> GetAllPaginatedAsync(int page, int take);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}