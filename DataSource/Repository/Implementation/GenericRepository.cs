using DataSource.Context;
using DataSource.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyApplicationContext _appDbContext;
        private DbSet<T> _dbSet;

        public GenericRepository(MyApplicationContext applicationContext)
        {
            _appDbContext = applicationContext;
            _dbSet = applicationContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception here or log it for debugging purposes.
                // You can choose to throw or return an empty list, depending on your requirements.
                throw;
            }
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle the exception here or log it for debugging purposes.
                // You can choose to throw or return null, depending on your requirements.
                throw;
            }
        }

        public virtual async Task<bool> InsertAsync(T entityToInsert)
        {
            try
            {
                await _dbSet.AddAsync(entityToInsert);
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception here or log it for debugging purposes.
                // You can choose to throw or return false, depending on your requirements.
                throw;
            }
        }

        public virtual async Task UpdateAsync(T entityToUpdate)
        {
            try
            {
                _dbSet.Update(entityToUpdate);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception here or log it for debugging purposes.
                throw;
            }
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            try
            {
                var entityToDelete = await _dbSet.FindAsync(id);
                if (entityToDelete != null)
                {
                    await DeleteAsync(entityToDelete);
                    return;
                }
                var typeName = typeof(T).Name;
                throw new ArgumentException($"{typeName} with Id {id} does not exist");
            }
            catch (Exception ex)
            {
                // Handle the exception here or log it for debugging purposes.
                throw;
            }
        }

        public async Task DeleteAsync(T entityToDelete)
        {
            try
            {
                _dbSet.Remove(entityToDelete);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception here or log it for debugging purposes.
                throw;
            }
        }

        protected virtual DbSet<T> Entities => _dbSet ??= _appDbContext.Set<T>();

        public virtual IQueryable<T> Table => Entities;

        public virtual IQueryable<T> TableNoTracking => Entities.AsNoTracking();

        private async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _appDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                // Handle the exception here or log it for debugging purposes.
                // You can choose to throw or return false, depending on your requirements.
                throw;
            }
        }
    }
}
