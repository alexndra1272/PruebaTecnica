using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Data.Models;
using Backend.UnitofWork;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            var personas = await _unitOfWork.Personas.GetAllAsync();
            return Ok(personas);
        }

        // GET: api/Persona/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _unitOfWork.Personas.GetByIdAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/Persona/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            try
            {
                // Verificar si el id de la ruta coincide con el id de la entidad
                if (id != persona.IdPersona)
                {
                    return BadRequest($"El ID proporcionado en la ruta no coincide con el ID de la persona. {id} != {persona.IdPersona}");
                }

                // Intentar actualizar la entidad
                var updateResult = await _unitOfWork.Personas.UpdateAsync(persona);

                // Verificar si la actualización fue exitosa
                if (!updateResult)
                {
                    return NotFound($"No se encontró la persona con ID {id}.");
                }

                // Intentar completar la transacción en la unidad de trabajo
                await _unitOfWork.CompleteAsync();

                // Devolver una respuesta exitosa
                return Ok($"Persona con ID {id} actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la operación
                // Aquí puedes registrar el error, devolver un BadRequest o NotFound, etc.
                return BadRequest($"Error al actualizar la persona: {ex.Message}");
            }
        }

        // POST: api/Persona
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            try
            {
                // Intentar agregar la entidad
                var addResult = await _unitOfWork.Personas.AddAsync(persona);

                // Verificar si la insercion fue exitosa
                if (!addResult)
                {
                    return BadRequest($"No se pudo agregar la persona.");
                }

                // Intentar completar la transacción en la unidad de trabajo
                await _unitOfWork.CompleteAsync();

                // Devolver una respuesta exitosa
                return Ok($"Persona agregada exitosamente.");
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la operación
                // Aquí puedes registrar el error, devolver un BadRequest o NotFound, etc.
                return BadRequest($"Error al agregar la persona: {ex.Message}");
            }
        }

        // DELETE: api/Persona/identificacion
        [HttpDelete("{identificacion}")]
        public async Task<ActionResult<Persona>> DeletePersona(string identificacion)
        {
            try
            {
                // Intentar eliminar la entidad
                var deleteResult = await _unitOfWork.Personas.DeletePersonaByIdentificacion(identificacion);

                // Verificar si la eliminación fue exitosa
                if (deleteResult == null)
                {
                    return NotFound($"No se encontró la persona con identificación {identificacion}.");
                }

                // Intentar completar la transacción en la unidad de trabajo
                await _unitOfWork.CompleteAsync();

                // Devolver una respuesta exitosa
                return Ok($"Persona con identificación {identificacion} eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la operación
                // Aquí puedes registrar el error, devolver un BadRequest o NotFound, etc.
                return BadRequest($"Error al eliminar la persona: {ex.Message}");
            }
        }
    }
}
