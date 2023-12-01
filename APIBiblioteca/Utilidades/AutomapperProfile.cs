using APIBiblioteca.DTO;
using APIBiblioteca.Models;
using AutoMapper;

namespace APIBiblioteca.Utilidades
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<AutorCreacionDTO, Autor>()
                .ForMember(d => d.FechaNacimiento,
                opt => opt.MapFrom(o => DateTime.Parse(o.FechaNacimiento))).ReverseMap();
            //CreateMap<Autor, AutorCreacionDTO>

            CreateMap<Autor, AutorDTO>()
                .ForMember(d => d.FechaNacimiento,
                opt => opt.MapFrom(o => o.FechaNacimiento.ToString("dd/MM/yyyy")));
        }
    }
}
