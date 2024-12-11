using GestorCursosAPI.Data;
using GestorCursosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorCursosAPI.Repositories.EstudianteRepository
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly GestorCursosDbContext _context;

        public EstudianteRepository(GestorCursosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudiante>> GetAllAsync()
        {
            return await _context.Estudiantes.Include(e => e.Cursos).ToListAsync();
        }

        public async Task<Estudiante> GetByIdAsync(int id)
        {
            return await _context.Estudiantes.Include(e => e.Cursos).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Estudiante estudiante)
        {
            await _context.Estudiantes.AddAsync(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Estudiante estudiante)
        {
            _context.Estudiantes.Update(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var estudiante = await GetByIdAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Estudiantes.AnyAsync(e => e.Id == id);
        }
    }
}
