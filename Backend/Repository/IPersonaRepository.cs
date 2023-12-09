using System.Threading.Tasks;
using Backend.Data.Models;

namespace Backend.Repository;

public interface IPersonaRepository : IGenericRepository<Persona>
{
    Task<Persona?> GetPersonaByIdentificacionorNameAsync(string identificacion, string nombre);
    Task<Persona?> DeletePersonaByIdentificacion(string identificacion);
}

