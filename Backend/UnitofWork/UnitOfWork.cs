using Backend.Data;
using Backend.Repository;

namespace Backend.UnitofWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;

    public IPersonaRepository Personas { get; private set; }

    public UnitOfWork(ApiDbContext context, ILogger<PersonaRepository> logger)
    {
        _context = context;
        Personas = new PersonaRepository(_context, logger);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}