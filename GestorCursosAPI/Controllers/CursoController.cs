using AutoMapper;
using GestorCursosAPI.DTOs.Cursos;
using GestorCursosAPI.Models;
using GestorCursosAPI.Services.CursoServices;
using Microsoft.AspNetCore.Mvc;

namespace GestorCursosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;
        private readonly IMapper _mapper;

        public CursosController(ICursoService cursoService, IMapper mapper)
        {
            _cursoService = cursoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCursos()
        {
            var cursos = await _cursoService.GetAllCursosAsync();
            var cursoDtos = _mapper.Map<IEnumerable<CursoReadDto>>(cursos);
            return Ok(cursoDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCursoById(int id)
        {
            var curso = await _cursoService.GetCursoByIdAsync(id);
            if (curso == null)
            {
                return NotFound($"El curso con ID {id} no existe.");
            }

            var cursoDto = _mapper.Map<CursoReadDto>(curso);
            return Ok(cursoDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCurso([FromBody] CursoCreateDto cursoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var curso = _mapper.Map<Curso>(cursoDto);
            await _cursoService.AddCursoAsync(curso);
            return CreatedAtAction(nameof(GetCursoById), new { id = curso.Id }, _mapper.Map<CursoReadDto>(curso));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurso(int id, [FromBody] CursoCreateDto cursoDto)
        {
            var curso = await _cursoService.GetCursoByIdAsync(id);
            if (curso == null)
            {
                return NotFound($"El curso con ID {id} no existe.");
            }

            _mapper.Map(cursoDto, curso);
            await _cursoService.UpdateCursoAsync(curso);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _cursoService.GetCursoByIdAsync(id);
            if (curso == null)
            {
                return NotFound($"El curso con ID {id} no existe.");
            }

            await _cursoService.DeleteCursoAsync(id);
            return NoContent();
        }
    }
}