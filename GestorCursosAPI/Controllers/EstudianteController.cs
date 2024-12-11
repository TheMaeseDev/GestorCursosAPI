using GestorCursosAPI.Models;
using GestorCursosAPI.Services.EstudianteServices;
using Microsoft.AspNetCore.Mvc;

namespace GestorCursosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;

        public EstudiantesController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        // Obtener todos los estudiantes
        [HttpGet]
        public async Task<IActionResult> GetAllEstudiantes()
        {
            var estudiantes = await _estudianteService.GetAllEstudiantesAsync();
            return Ok(estudiantes);
        }

        // Obtener un estudiante por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstudianteById(int id)
        {
            var estudiante = await _estudianteService.GetEstudianteByIdAsync(id);
            if (estudiante == null)
            {
                return NotFound($"El estudiante con ID {id} no existe.");
            }
            return Ok(estudiante);
        }

        // Crear un estudiante
        [HttpPost]
        public async Task<IActionResult> AddEstudiante([FromBody] Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _estudianteService.AddEstudianteAsync(estudiante);
            return CreatedAtAction(nameof(GetEstudianteById), new { id = estudiante.Id }, estudiante);
        }

        // Actualizar un estudiante
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstudiante(int id, [FromBody] Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return BadRequest("El ID del estudiante no coincide con el ID de la URL.");
            }

            var existe = await _estudianteService.GetEstudianteByIdAsync(id);
            if (existe == null)
            {
                return NotFound($"El estudiante con ID {id} no existe.");
            }

            await _estudianteService.UpdateEstudianteAsync(estudiante);
            return NoContent();
        }

        // Eliminar un estudiante
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _estudianteService.GetEstudianteByIdAsync(id);
            if (estudiante == null)
            {
                return NotFound($"El estudiante con ID {id} no existe.");
            }

            await _estudianteService.DeleteEstudianteAsync(id);
            return NoContent();
        }
    }
}
