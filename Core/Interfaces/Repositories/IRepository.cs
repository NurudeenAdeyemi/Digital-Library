using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(int id);

        Task<IEnumerable<T>> GetAsync(IList<int> ids);

        Task<bool> ExistsAsync(int id);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        IQueryable<T> Query();

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task DeleteAsync(T entity);

        IQueryable<T> Query(Expression<Func<T, bool>> expression);

        Task<int> SaveChangesAsync();
    }
}
