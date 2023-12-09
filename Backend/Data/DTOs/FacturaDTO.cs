namespace Backend.Data.DTOs
{
    public class FacturaDTO
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int IdPersona { get; set; }
        public string NombrePersona { get; set; }
    }
}
