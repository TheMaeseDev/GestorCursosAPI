using AutoMapper;
using GestorCursosAPI.DTOs.Categorias;
using GestorCursosAPI.DTOs.Cursos;
using GestorCursosAPI.DTOs.Estudiantes;
using GestorCursosAPI.Models;

namespace GestorCursosAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Curso, CursoReadDto>();
            CreateMap<CursoCreateDto, Curso>();

            CreateMap<Estudiante, EstudianteReadDto>()
               .ForMember(dest => dest.CursosIds, opt => opt.MapFrom(src => src.Cursos.Select(c => c.Id).ToList()));
            CreateMap<EstudianteCreateDto, Estudiante>();

            // Mapear Categoria a CategoriaDto y viceversa
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<CategoriaCreateUpdateDto, Categoria>();
        }
    }
}
