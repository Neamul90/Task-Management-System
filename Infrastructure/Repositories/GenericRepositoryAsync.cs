using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext
                  .Set<T>()
                  .LastOrDefaultAsync(predicate);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = _dbContext
               .Set<T>()
                .Where(predicate)
                .AsNoTracking();
            query = includeExpressions.Aggregate(query, (current, inc) => current.Include(inc));
            return await query.LastOrDefaultAsync();
        }
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize)
        {
            return await _dbContext
                 .Set<T>()
                 .Where(predicate)
                 .Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize)
                 .AsNoTracking()
                 .ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = _dbContext.Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking();
            query = includeExpressions.Aggregate(query, (current, inc) => current.Include(inc));
            return await query.Where(predicate).ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize, params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = _dbContext.Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking();
            query = includeExpressions.Aggregate(query, (current, inc) => current.Include(inc));
            return await query.ToListAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(IEnumerable<T> entity)
        {
            _dbContext.Set<T>().RemoveRange(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext
                 .Set<T>()
                 .ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext
                 .Set<T>()
                 .Where(predicate)
                 .ToListAsync();
        }
    }
}
