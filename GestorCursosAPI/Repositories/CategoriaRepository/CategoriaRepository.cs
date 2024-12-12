using GestorCursosAPI.Data;
using GestorCursosAPI.Models;
using GestorCursosAPI.Repositories.CategoriaRepository;
using Microsoft.EntityFrameworkCore;

namespace GestorCursosAPI.Repositories.Categorias
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly GestorCursosDbContext _context;

        public CategoriaRepository(GestorCursosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetCategoriaByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task AddCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}