using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Backend.Data.Models
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
		public int IdPersona { get; set; }

        // Propiedad de navegación
        [JsonIgnore]
        public Persona? Persona { get; set; }
    }
}
