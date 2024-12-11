using AutoMapper;
using GestorCursosAPI.Data;
using GestorCursosAPI.DTOs.Estudiantes;
using GestorCursosAPI.DTOs.Relaciones.CursoEstudiante;
using Microsoft.EntityFrameworkCore;


namespace GestorCursosAPI.Services.Relaciones.CursoEstudianteServices
{
    public class CursoEstudianteService : ICursoEstudianteService
    {
        private readonly GestorCursosDbContext _context;
        private readonly IMapper _mapper;

        public CursoEstudianteService(GestorCursosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AsignarEstudianteACursoAsync(int estudianteId, int cursoId)
        {
            var estudiante = await _context.Estudiantes.FindAsync(estudianteId);
            var curso = await _context.Cursos.FindAsync(cursoId);

            if (estudiante == null || curso == null)
                throw new ArgumentException("El estudiante o el curso no existen.");

            curso.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarEstudianteDeCursoAsync(int estudianteId, int cursoId)
        {
            var curso = await _context.Cursos.Include(c => c.Estudiantes).FirstOrDefaultAsync(c => c.Id == cursoId);
            if (curso == null)
                throw new ArgumentException("El curso no existe.");

            var estudiante = curso.Estudiantes.FirstOrDefault(e => e.Id == estudianteId);
            if (estudiante == null)
                throw new ArgumentException("El estudiante no está asignado a este curso.");

            curso.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CursoConEstudiantesDto>> GetCursosConEstudiantesAsync()
        {
            var cursos = await _context.Cursos.Include(c => c.Estudiantes).ToListAsync();
            return cursos.Select(c => new CursoConEstudiantesDto
            {
                CursoId = c.Id,
                NombreCurso = c.Nombre,
                Estudiantes = _mapper.Map<List<EstudianteReadDto>>(c.Estudiantes)
            });
        }
    }
}
