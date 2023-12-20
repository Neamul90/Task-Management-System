using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, params Expression<Func<T, object>>[] includeExpressions);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize, params Expression<Func<T, object>>[] includeExpressions);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(IEnumerable<T> entities);
    }
}
