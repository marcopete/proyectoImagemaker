using System.Linq;
using AutoMapper;
using proyectoImagemaker.API.Dtos;
using proyectoImagemaker.API.Models;

namespace proyectoImagemaker.API.Helpers
{
    public class PerfilesAutoMapper : Profile
    {
        public PerfilesAutoMapper()
        {
            CreateMap<Usuario, UsuarioParaListarDto>()
                .ForMember(dest => dest.UrlFoto, opt =>
                    opt.MapFrom(src =>src.Fotos.First(p => p.FotoPrincipal).Url))
                .ForMember(dest => dest.Edad, opt =>
                    opt.MapFrom(src => src.FechaNacimiento.CalculoEdad()));    
            CreateMap<Usuario, UsuarioParaDetallesDto>()
                .ForMember(dest => dest.UrlFoto, opt =>
                    opt.MapFrom(src =>src.Fotos.FirstOrDefault(p => p.FotoPrincipal).Url))
                .ForMember(dest => dest.Edad, opt =>
                    opt.MapFrom(src => src.FechaNacimiento.CalculoEdad()));
            CreateMap<Foto, FotosParaDetallesDto>();
        }
    }
}