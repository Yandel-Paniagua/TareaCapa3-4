using AutoMapper;
using UnaApi2.Application.DTOs;
using UnaApi2.Domain.Entities;

namespace UnaApi2.Application.Mapping
{
    public class LecturasClimaticaProfile : Profile
    {
        public LecturasClimaticaProfile()
        {
            CreateMap<LecturasClimatica, LecturasClimaticaReadDto>();
            
            CreateMap<LecturasClimaticaCreateDto, LecturasClimatica>();
            
            CreateMap<LecturasClimaticaUpdateDto, LecturasClimatica>();
        }
    }
}