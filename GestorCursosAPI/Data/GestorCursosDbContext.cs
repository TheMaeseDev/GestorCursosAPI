using Microsoft.EntityFrameworkCore;
using GestorCursosAPI.Models;

namespace GestorCursosAPI.Data
{
    public class GestorCursosDbContext : DbContext
    {
        public GestorCursosDbContext(DbContextOptions<GestorCursosDbContext> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación muchos a muchos
            modelBuilder.Entity<Curso>()
                .HasMany(c => c.Estudiantes)
                .WithMany(e => e.Cursos)
                .UsingEntity(j => j.ToTable("CursoEstudiantes"));
        }
    }
}
