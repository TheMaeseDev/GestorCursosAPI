using GestorCursosAPI.DTOs.Relaciones.CursoEstudiante;
using GestorCursosAPI.Services.Relaciones.CursoEstudianteServices;
using Microsoft.AspNetCore.Mvc;

namespace GestorCursosAPI.Controllers.Relaciones
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoEstudianteController : ControllerBase
    {
        private readonly ICursoEstudianteService CursoEstudianteService;

        public CursoEstudianteController(ICursoEstudianteService relacionService)
        {
            CursoEstudianteService = relacionService;
        }

        [HttpPost("AsignarEstudianteACurso")]
        public async Task<IActionResult> AsignarEstudianteACurso([FromBody] AsignarEstudianteACursoDto dto)
        {
            try
            {
                await CursoEstudianteService.AsignarEstudianteACursoAsync(dto.EstudianteId, dto.CursoId);
                return Ok("Estudiante asignado al curso con éxito.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("EliminarEstudianteDeCurso")]
        public async Task<IActionResult> EliminarEstudianteDeCurso([FromBody] AsignarEstudianteACursoDto dto)
        {
            try
            {
                await CursoEstudianteService.EliminarEstudianteDeCursoAsync(dto.EstudianteId, dto.CursoId);
                return Ok("Estudiante eliminado del curso con éxito.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("CursosConEstudiantes")]
        public async Task<IActionResult> GetCursosConEstudiantes()
        {
            var cursos = await CursoEstudianteService.GetCursosConEstudiantesAsync();
            return Ok(cursos);
        }
    }
}
