namespace GestorCursosAPI.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        // Relación con Cursos
        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
    }
}
