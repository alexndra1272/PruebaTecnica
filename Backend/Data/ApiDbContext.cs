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

		public DbSet<Persona> Personas { get; set; } = null!;
		public DbSet<Factura> Factura { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
				.HasKey(p => p.IdPersona);


            modelBuilder.Entity<Factura>()
                .HasKey(f => f.IdFactura); 
				
			modelBuilder.Entity<Persona>()
				.HasMany(p => p.Factura)  
				.WithOne(f => f.Persona)
				.HasForeignKey(f => f.IdPersona)
				.OnDelete(DeleteBehavior.Cascade);

        }


    }
}

