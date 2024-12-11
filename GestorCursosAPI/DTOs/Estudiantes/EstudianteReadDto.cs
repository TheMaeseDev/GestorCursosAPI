namespace GestorCursosAPI.DTOs.Estudiantes
{
    public class EstudianteReadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public List<int> CursosIds { get; set; } = new List<int>(); // Lista de IDs de cursos relacionados
    }
}
