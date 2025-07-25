using AutoMapper;
using UnaApi2.Application.DTOs;
using UnaApi2.Domain.Entities;

namespace UnaApi2.Application.Mapping
{
    public class MunicipalityProfile : Profile
    {
        public MunicipalityProfile()
        {
            CreateMap<Municipality, MunicipalityReadDto>();
            
            CreateMap<MunicipalityCreateDto, Municipality>();
            
            CreateMap<MunicipalityUpdateDto, Municipality>();
        }
    }
}