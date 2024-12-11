using GestorCursosAPI.Models;

namespace GestorCursosAPI.Services.EstudianteServices
{
    public interface IEstudianteService
    {
        Task<IEnumerable<Estudiante>> GetAllEstudiantesAsync();
        Task<Estudiante> GetEstudianteByIdAsync(int id);
        Task AddEstudianteAsync(Estudiante estudiante);
        Task UpdateEstudianteAsync(Estudiante estudiante);
        Task DeleteEstudianteAsync(int id);
    }
}
