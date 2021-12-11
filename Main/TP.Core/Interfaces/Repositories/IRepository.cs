using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TP.Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        Task<IEnumerable<T>> GetAsync();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        T Get(string id);
        Task<T> GetAsync(string id);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        T Update(T entity, string id);
        Task<T> UpdateAsync(T entity, string id);
        void Delete(T entity);
        Task<bool> Delete(string id);
        Task Save();
    }
}
