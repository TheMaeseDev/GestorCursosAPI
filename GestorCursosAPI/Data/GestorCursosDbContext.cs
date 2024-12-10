using Microsoft.EntityFrameworkCore;
using GestorCursosAPI.Models;

namespace GestorCursosAPI.Data
{
    public class GestorCursosDbContext : DbContext
    {
        public GestorCursosDbContext(DbContextOptions<GestorCursosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }
    }
}
