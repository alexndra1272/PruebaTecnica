
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Backend.Data.Models
{

    [Index(nameof(Identificacion), IsUnique = true)]
    public class Persona
    {
        [Required]
        public int IdPersona { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApellidPaterno { get; set; }

        public string? ApellidMaterno { get; set; } = null!; //optional

        [Required]
        public string Identificacion { get; set; }


        // nav property
        public List<Factura>? Factura { get; set; }
    }
}