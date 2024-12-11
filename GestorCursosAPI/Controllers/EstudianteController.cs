using GestorCursosAPI.Models;
using GestorCursosAPI.Services.EstudianteServices;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GestorCursosAPI.DTOs.Estudiantes;

namespace GestorCursosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;
        private readonly IMapper _mapper;

        public EstudiantesController(IEstudianteService estudianteService, IMapper mapper)
        {
            _estudianteService = estudianteService;
            _mapper = mapper;
        }

        // Obtener todos los estudiantes
        [HttpGet]
        public async Task<IActionResult> GetAllEstudiantes()
        {
            var estudiantes = await _estudianteService.GetAllEstudiantesAsync();
            var estudianteDtos = _mapper.Map<IEnumerable<EstudianteReadDto>>(estudiantes);
            return Ok(estudianteDtos);
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
            var estudianteDto = _mapper.Map<EstudianteReadDto>(estudiante);
            return Ok(estudianteDto);
        }

        // Crear un estudiante
        [HttpPost]
        public async Task<IActionResult> AddEstudiante([FromBody] EstudianteCreateDto estudianteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var estudiante = _mapper.Map<Estudiante>(estudianteDto);
            await _estudianteService.AddEstudianteAsync(estudiante);
            return CreatedAtAction(nameof(GetEstudianteById), new { id = estudiante.Id }, _mapper.Map<EstudianteReadDto>(estudiante));
        }

        // Actualizar un estudiante
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstudiante(int id, [FromBody] EstudianteCreateDto estudianteDto)
        {
            var estudiante = await _estudianteService.GetEstudianteByIdAsync(id);
            if (estudiante == null)
            {
                return NotFound($"El estudiante con ID {id} no existe.");
            }

            _mapper.Map(estudianteDto, estudiante);
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
