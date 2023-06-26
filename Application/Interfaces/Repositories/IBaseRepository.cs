using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Pagination;

namespace Application.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> Find(Expression<Func<T, bool>> filterExpression, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<PaginatedData<T>> GetAllPaginatedAsync(int page, int take, params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}