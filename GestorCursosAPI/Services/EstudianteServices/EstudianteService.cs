using GestorCursosAPI.Models;
using GestorCursosAPI.Repositories.EstudianteRepository;

namespace GestorCursosAPI.Services.EstudianteServices
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public async Task<IEnumerable<Estudiante>> GetAllEstudiantesAsync()
        {
            return await _estudianteRepository.GetAllAsync();
        }

        public async Task<Estudiante> GetEstudianteByIdAsync(int id)
        {
            return await _estudianteRepository.GetByIdAsync(id);
        }

        public async Task AddEstudianteAsync(Estudiante estudiante)
        {
            await _estudianteRepository.AddAsync(estudiante);
        }

        public async Task UpdateEstudianteAsync(Estudiante estudiante)
        {
            await _estudianteRepository.UpdateAsync(estudiante);
        }

        public async Task DeleteEstudianteAsync(int id)
        {
            await _estudianteRepository.DeleteAsync(id);
        }
    }
}
