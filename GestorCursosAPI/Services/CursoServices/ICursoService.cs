using GestorCursosAPI.Models;

namespace GestorCursosAPI.Services.CursoServices
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetAllCursosAsync();
        Task<Curso> GetCursoByIdAsync(int id);
        Task AddCursoAsync(Curso curso);
        Task UpdateCursoAsync(Curso curso);
        Task DeleteCursoAsync(int id);
    }
}
