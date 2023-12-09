using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.models
{
    public class Personas
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidPaterno { get; set; }
        public string? ApellidMaterno { get; set; } = null!; //optional
        public string Identificacion { get; set; }
    }
}
