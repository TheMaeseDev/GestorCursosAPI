using AutoMapper;
using GestorCursosAPI.DTOs.Cursos;
using GestorCursosAPI.Models;

namespace GestorCursosAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Curso, CursoReadDto>();
            CreateMap<CursoCreateDto, Curso>();
        }
    }
}
