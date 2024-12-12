using GestorCursosAPI.Models;

namespace GestorCursosAPI.Services.CategoriaServices
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAllCategoriasAsync();
        Task<Categoria> GetCategoriaByIdAsync(int id);
        Task AddCategoriaAsync(Categoria categoria);
        Task UpdateCategoriaAsync(Categoria categoria);
        Task DeleteCategoriaAsync(int id);
    }
}
