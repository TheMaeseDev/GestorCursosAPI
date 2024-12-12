using GestorCursosAPI.Models;
using GestorCursosAPI.Services.CategoriaServices;
using Microsoft.AspNetCore.Mvc;

namespace GestorCursosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategorias()
        {
            var categorias = await _categoriaService.GetAllCategoriasAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaById(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
                return NotFound($"Categoría con ID {id} no encontrada.");

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoria([FromBody] Categoria categoria)
        {
            await _categoriaService.AddCategoriaAsync(categoria);
            return CreatedAtAction(nameof(GetCategoriaById), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] Categoria categoria)
        {
            categoria.Id = id;
            await _categoriaService.UpdateCategoriaAsync(categoria);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            await _categoriaService.DeleteCategoriaAsync(id);
            return NoContent();
        }
    }
}
