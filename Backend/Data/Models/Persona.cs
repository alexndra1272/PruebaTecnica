using System;
namespace Backend.Data.Models
{
    public class Persona
    {
        [ Required ]
        public int IdPersona { get; set; }
        [ Required ]
        public string Nombre { get; set; }
        [ Required ]
        public string ApellidPaterno { get; set; }

        public string? ApellidMaterno { get; set; } = null!; //optional

        [ Required ]
        [ MaxLength(15) ]
        [ Index(IsUnique = true) ]
        public string Identificacion { get; set; }


        // nav property
        public List<Factura>? Factura { get; set; }
    }
}