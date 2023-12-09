using System;
using Backend.Data.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;



namespace Backend.Repository;

public class FacturaRepository : GenericRepository<Factura>, IFacturaRepository
{
	private ApiDbContext context;
	private ILogger logger;
	internal DbSet<Factura> dbSet;

	public FacturaRepository(ApiDbContext context, ILogger<FacturaRepository> logger)
		: base(context, logger)
	{
		this.context = context;
		this.logger = logger;
		this.dbSet = context.Set<Factura>();
	}
	public async Task<IEnumerable<Factura>> GetFacturasWithDetailsAsync()
	{
		try
		{
			return await dbSet
				.Include(f => f.Persona) 
				.ToListAsync();
		}
		catch (Exception ex)
		{
			logger.LogError($"Error al obtener los registros de {typeof(Factura).Name}: {ex.Message}");
			return new List<Factura>(); // Puedes devolver una lista vacía o manejar el error según sea necesario
		}
	}



}


