using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Backend.Data;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApiDbContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(ApiDbContext context, ILogger<GenericRepository<T>> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener todos los registros de {typeof(T).Name}: {ex.Message}");
                return new List<T>();
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el registro con id {id} de {typeof(T).Name}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al agregar el registro de {typeof(T).Name}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el registro de {typeof(T).Name}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el registro con id {id} de {typeof(T).Name}: {ex.Message}");
                return false;
            }
        }
    }
}
