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


            //al tener las mismas propiedades y nombres que las entidades no causa error
            CreateMap<Genero, GeneroDTO>();
            CreateMap<GeneroCreacionDTO, Genero>().ReverseMap();


            // la letra "o" significa >> el Origen
            CreateMap<Libro, LibroDTO>()
                .ForMember(d =>d.NombreAutor, o => o.MapFrom(src => src.Autor.Nombre))
                .ForMember(d => d.NombreGenero, o => o.MapFrom(src => src.Genero.Nombre))
                .ForMember(d => d.FechaLanzamiento, opt => opt.MapFrom(o => o.FechaLanzamiento.ToString("dd/MM/yyyy")));
            //mapeo para ignorar variables

            CreateMap<LibroCreacionDTO, Libro>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Autor, o => o.Ignore())
                .ForMember(d => d.Genero, o => o.Ignore());

        }
    }
}
