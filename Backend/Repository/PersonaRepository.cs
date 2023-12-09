
using Backend.Data;
using Backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        private ApiDbContext context;
        private ILogger logger;
        internal DbSet<Persona> dbSet;

        public PersonaRepository(ApiDbContext context, ILogger<PersonaRepository> logger)
            : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
            this.dbSet = context.Set<Persona>();
        }

        public async Task<Persona?> GetPersonaByIdentificacionorNameAsync(string identificacion, string nombre)
        {
            try
            {
                return await dbSet.Where(p => EF.Functions.Like(p.Identificacion, $"%{identificacion}%") || EF.Functions.Like(p.Nombre, $"%{nombre}%")).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error al obtener el registro con identificacion o nombre {identificacion} de {typeof(Persona).Name}: {ex.Message}");
                return null;
            }
        }

        public async Task<Persona?> DeletePersonaByIdentificacion(string identificacion)
        {
            try
            {
                var persona = await dbSet.FirstOrDefaultAsync(p => p.Identificacion == identificacion);
                if (persona != null)
                {
                    dbSet.Remove(persona);
                    return persona;
                }
                return null;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error al eliminar el registro con identificacion {identificacion} de {typeof(Persona).Name}: {ex.Message}");
                return null;
            }
        }

    }
}
