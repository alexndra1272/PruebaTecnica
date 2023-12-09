using System.Threading.Tasks;
using Backend.Data.Models;

namespace Backend.Repository;

public interface IPersonaRepository : IGenericRepository<Persona>
{
    Task<List<Persona?>> GetPersonaByIdentificacionorNameAsync(string searchTerm);
    Task<Persona?> DeletePersonaByIdentificacion(string identificacion);
}

