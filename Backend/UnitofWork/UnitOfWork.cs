using Backend.Data;
using Backend.Repository;

namespace Backend.UnitofWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;

    public IPersonaRepository Personas { get; private set; }
    public IFacturaRepository Facturas { get; private set; }

    public UnitOfWork(ApiDbContext context, ILogger<PersonaRepository> logger, ILogger<FacturaRepository> logger2)
    {
        _context = context;
        Personas = new PersonaRepository(_context, logger);
        Facturas = new FacturaRepository(_context, logger2);

        
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