using GestorCursosAPI.Models;
using GestorCursosAPI.Repositories.CategoriaRepository;

namespace GestorCursosAPI.Services.CategoriaServices
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
        {
            return await _categoriaRepository.GetAllCategoriasAsync();
        }

        public async Task<Categoria> GetCategoriaByIdAsync(int id)
        {
            return await _categoriaRepository.GetCategoriaByIdAsync(id);
        }

        public async Task AddCategoriaAsync(Categoria categoria)
        {
            await _categoriaRepository.AddCategoriaAsync(categoria);
        }

        public async Task UpdateCategoriaAsync(Categoria categoria)
        {
            await _categoriaRepository.UpdateCategoriaAsync(categoria);
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            await _categoriaRepository.DeleteCategoriaAsync(id);
        }
    }
}
