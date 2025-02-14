using API.Models;
using Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Cryptography;
using Domain.Models;
using Microsoft.Extensions.Logging;
using DAL.Helper;

namespace Data.Repository
{
    public  class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbmindCareContext _context;
        protected readonly DbSet<T> _dbSet;
        protected readonly ILogger<Repository<T>> _logger;

        public Repository(DbmindCareContext context, ILogger<Repository<T>> logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting all entities of type {typeof(T).Name}");
                throw;
            }
        }

        public async Task<PaginatedList<T>> GetPaginatedResult(int pageNumber, int pageSize)
        {
            try
            {
                var count = await _dbSet.CountAsync();
                var items = await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

                return new PaginatedList<T>(items, count, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting all entities of type {typeof(T).Name}");
                throw;
            }    
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _dbSet;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting all entities of type {typeof(T).Name}");
                throw;
            }
        }
         
        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting an entity of type {typeof(T).Name} with id {id}");
                throw;
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while adding an entity of type {typeof(T).Name}");
                throw;
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating an entity of type {typeof(T).Name}");
                throw;
            }
        }

        public async Task SoftDeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _context.Entry(entity).Property("Estado").CurrentValue = false;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while performing soft delete on entity of type {typeof(T).Name} with id {id}");
                throw;
            }
        }

        public async Task HardDeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while performing hard delete on entity of type {typeof(T).Name} with id {id}");
                throw;
            }
        }
        public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await Task.FromResult(_dbSet.Where(predicate));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while filtering entities of type {typeof(T).Name}");
                throw;
            }
        }
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _dbSet.AnyAsync(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while checking existence of entities of type {typeof(T).Name}");
                throw;
            }
        }

        public async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _dbSet.FirstAsync(predicate);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while checking existence of entities of type {typeof(T).Name}");
                throw;
            }
        }
    }
}
