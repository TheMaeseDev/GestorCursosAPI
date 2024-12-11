using GestorCursosAPI.DTOs.Relaciones.CursoEstudiante;

namespace GestorCursosAPI.Services.Relaciones.CursoEstudianteServices
{
    public interface ICursoEstudianteService
    {
        Task AsignarEstudianteACursoAsync(int estudianteId, int cursoId);
        Task EliminarEstudianteDeCursoAsync(int estudianteId, int cursoId);
        Task<IEnumerable<CursoConEstudiantesDto>> GetCursosConEstudiantesAsync();
    }
}
