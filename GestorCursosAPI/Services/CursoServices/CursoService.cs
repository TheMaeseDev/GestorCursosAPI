using GestorCursosAPI.Models;
using GestorCursosAPI.Repositories.CursoRepository;

namespace GestorCursosAPI.Services.CursoServices
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<IEnumerable<Curso>> GetAllCursosAsync()
        {
            return await _cursoRepository.GetAllAsync();
        }

        public async Task<Curso> GetCursoByIdAsync(int id)
        {
            return await _cursoRepository.GetByIdAsync(id);
        }

        public async Task AddCursoAsync(Curso curso)
        {
            await _cursoRepository.AddAsync(curso);
        }

        public async Task UpdateCursoAsync(Curso curso)
        {
            await _cursoRepository.UpdateAsync(curso);
        }

        public async Task DeleteCursoAsync(int id)
        {
            await _cursoRepository.DeleteAsync(id);
        }
    }
}
