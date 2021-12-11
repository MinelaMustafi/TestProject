using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Interfaces.Repositories;

namespace TP.Infrastructure.Repositories.EFCore
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected Context context;
        protected DbSet<T> dbSet;

        public Repository(Context context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }


        public IEnumerable<T> Get()
        {
            try
            {
                return dbSet.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities from database: {ex.Message}");
            }
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities from database: {ex.Message}");
            }
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return dbSet.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities from database: {ex.Message}");
            }
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await dbSet.Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities from database: {ex.Message}");
            }
        }

        public T Get(string id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity from database: {ex.Message}");
            }
        }

        public async Task<T> GetAsync(string id)
        {
            try
            {
                return await dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity from database: {ex.Message}");
            }
        }

        public T Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity can't be null.");
            try
            {
                entity.Create(context);
                dbSet.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't save entity to database: {ex.Message}");
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity can't be null.");
            try
            {
                await entity.CreateAsync(context);
                await dbSet.AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't save entity to database: {ex.Message}");
            }
        }

        public T Update(T entity, string id)
        {
            if(entity==null)
                throw new ArgumentNullException("Entity can't be null.");
            try
            {
                T oldEntity = Get(id);
                entity.Create(context);
                context.Entry(oldEntity).CurrentValues.SetValues(entity);
                oldEntity.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't update entity in database: {ex.Message}");
            }
        }

        public async Task<T> UpdateAsync(T entity, string id)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity can't be null.");
            try
            {
                T oldEntity = await GetAsync(id);
                await entity.CreateAsync(context);
                context.Entry(oldEntity).CurrentValues.SetValues(entity);
                oldEntity.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't update entity in database: {ex.Message}");
            }
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                T entity = await GetAsync(id);
                if (entity == null || !entity.CanDelete()) return false;
                Delete(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't delete entity from database: {ex.Message}");
            }
        }


        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
