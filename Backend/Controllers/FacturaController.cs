using Backend.Data.Models;
using Backend.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public FacturaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Factura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas()
        {
            // Obtener las facturas con sus detalles
            var facturas = await _unitOfWork.Facturas.GetFacturasWithDetailsAsync();

            return Ok(facturas);
        }

        // GET: api/Factura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetFactura(int id)
        {
            var factura = await _unitOfWork.Facturas.GetByIdAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            return Ok(factura);
        }

        // POST: api/Factura
        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura factura)
        {
            try
            {
                // Buscamos el cliente
                var persona = await _unitOfWork.Personas.GetByIdAsync(factura.IdPersona);

                // Verificamos si existe el cliente
                if (persona == null)
                {
                    return BadRequest($"No existe el cliente con ID {factura.IdPersona}");
                }

                // Asignar la persona a la factura
                factura.Persona = persona;

                // Agregamos la factura
                var facturaAgregada = await _unitOfWork.Facturas.AddAsync(factura);

                if (facturaAgregada == null)
                {
                    return BadRequest("Error al agregar la factura.");
                }

                // Intentamos guardar los cambios
                await _unitOfWork.CompleteAsync();

                // Retornamos el resultado
                return Ok($"Se agregó la factura para el cliente {factura.Persona.Nombre}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al agregar la factura: {ex.Message}");
            }
        }

        //PUT: api/Factura/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, Factura factura)
        {
            if (id != factura.IdFactura)
            {
                return BadRequest();
            }

            _unitOfWork.Facturas.UpdateAsync(factura);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok($"Se actualizó la factura con ID {id}");

        }
        // DELETE: api/Factura/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            var factura = await _unitOfWork.Facturas.GetByIdAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _unitOfWork.Facturas.DeleteAsync(factura.IdFactura);
            await _unitOfWork.CompleteAsync();

            return Ok($"Se eliminó la factura con ID {id}");


        }

    }
}