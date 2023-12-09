using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.models
{
    public class Facturas
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public String NombrePersona { get; set; }
        public int IdPersona { get; set; }

    }
}
