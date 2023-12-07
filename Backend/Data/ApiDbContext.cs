using System;
using Microsoft.EntityFrameworkCore;
using Backend.Data.Models;

namespace Backend.Data
{
	public class ApiDbContext : DbContext
	{
		public ApiDbContext(DbContextOptions<ApiDbContext> options) 
			: base(options)
		{
		}
		public DbSet<Factura> Facturas { get; set; } = null!;
		public DbSet<Persona> Personas { get; set; } = null!;
		
	}
}

