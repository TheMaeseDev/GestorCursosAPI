using System.ComponentModel.DataAnnotations;

namespace GestorCursosAPI.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
    }
}
