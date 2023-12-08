using System;
using Backend.Data.Models;
using Backend.Data;

namespace Backend.Repository;

public class FacturaRepository : GenericRepository<Factura>, IFacturaRepository
{
	private ApiDbContext context;
	private ILogger logger;

	public FacturaRepository(ApiDbContext context, ILogger<FacturaRepository> logger)
		: base(context, logger)
	{
	}

}


