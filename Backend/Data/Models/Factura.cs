using System;
namespace Backend.Data.Models
{
	public class Factura
	{
		public int IdFactura { get; set; }
		public DateTime Fecha { get; set; }
		public Decimal Monto { get; set; }
		public int IdPersona { get; set; }

		// Navigation Properties
		public Persona Persona { get; set; } = null!;
		
	}
}

