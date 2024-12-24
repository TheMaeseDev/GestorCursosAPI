using GestorCursosAPI.Repositories.CategoriaRepository;
using GestorCursosAPI.Models;

namespace GestorCursosAPI.Services.CategoriaServices
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _repository.AddAsync(categoria);
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            await _repository.UpdateAsync(categoria);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
