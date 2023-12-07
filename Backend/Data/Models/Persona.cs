using System;
namespace Backend.Data.Models
{
	public class Persona
	{
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidPaterno { get; set; }
        public string? ApellidMaterno { get; set; } = null!; //optional
        public string Identificacion { get; set; }
    }
}
