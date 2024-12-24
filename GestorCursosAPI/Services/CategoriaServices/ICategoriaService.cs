using GestorCursosAPI.Models;

namespace GestorCursosAPI.Services.CategoriaServices
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria> GetByIdAsync(int id);
        Task AddAsync(Categoria categoria);
        Task UpdateAsync(Categoria categoria);
        Task DeleteAsync(int id);
    }
}
