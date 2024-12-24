using AutoMapper;
using GestorCursosAPI.DTOs.Categorias;
using GestorCursosAPI.Services.CategoriaServices;
using Microsoft.AspNetCore.Mvc;
using GestorCursosAPI.Models;

namespace GestorCursosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _categoriaService.GetAllAsync();
            var categoriasDto = _mapper.Map<List<CategoriaDto>>(categorias);
            return Ok(categoriasDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria == null)
                return NotFound($"No se encontró una categoría con el ID {id}.");

            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            return Ok(categoriaDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriaCreateUpdateDto categoriaCreateUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoria = _mapper.Map<Categoria>(categoriaCreateUpdateDto);
            await _categoriaService.AddAsync(categoria);

            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            return CreatedAtAction(nameof(GetById), new { id = categoriaDto.Id }, categoriaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriaCreateUpdateDto categoriaCreateUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoriaExistente = await _categoriaService.GetByIdAsync(id);
            if (categoriaExistente == null)
                return NotFound($"No se encontró una categoría con el ID {id}.");

            _mapper.Map(categoriaCreateUpdateDto, categoriaExistente);
            await _categoriaService.UpdateAsync(categoriaExistente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria == null)
                return NotFound($"No se encontró una categoría con el ID {id}.");

            await _categoriaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
