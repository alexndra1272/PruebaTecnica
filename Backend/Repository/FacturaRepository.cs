using System;
using Backend.Data.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Backend.Data.DTOs;



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
    public async Task<IEnumerable<FacturaDTO>> GetFacturasWithDetailsAsync()
    {
        try
        {
            var facturas = await dbSet
                .Include(f => f.Persona)
            .ToListAsync();

            var facturasDto = facturas.Select(factura => new FacturaDTO
            {
                IdFactura = factura.IdFactura,
                Fecha = factura.Fecha,
                Monto = factura.Monto,
                IdPersona = factura.IdPersona,
                NombrePersona = factura.Persona.Nombre +" " + factura.Persona.ApellidPaterno
            });

            return facturasDto;
        }
        catch (Exception ex)
        {
            logger.LogError($"Error al obtener los registros de {typeof(Factura).Name}: {ex.Message}");
            return new List<FacturaDTO>();
        }
    }

}


