using GestorCursosAPI.DTOs.Estudiantes;

namespace GestorCursosAPI.DTOs.Relaciones.CursoEstudiante
{
    public class CursoConEstudiantesDto
    {
        public int CursoId { get; set; }
        public string NombreCurso { get; set; }
        public List<EstudianteReadDto> Estudiantes { get; set; } = new List<EstudianteReadDto>();
    }
}
