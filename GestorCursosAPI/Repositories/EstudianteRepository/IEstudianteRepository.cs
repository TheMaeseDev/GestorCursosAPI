using GestorCursosAPI.Models;

namespace GestorCursosAPI.Repositories.EstudianteRepository
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<Estudiante>> GetAllAsync();
        Task<Estudiante> GetByIdAsync(int id);
        Task AddAsync(Estudiante estudiante);
        Task UpdateAsync(Estudiante estudiante);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
