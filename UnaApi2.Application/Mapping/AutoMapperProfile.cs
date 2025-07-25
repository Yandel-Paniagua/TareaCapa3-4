using AutoMapper;
        using UnaApi2.Application.DTOs;
        using UnaApi2.Domain.Entities;


namespace UnaApi2.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<District, DistrictReadDto>();
            CreateMap<Municipality, MunicipalityReadDto>();
            CreateMap<DistrictCreateDto, District>();
            CreateMap<MunicipalityCreateDto, Municipality>();
            CreateMap<DistrictUpdateDto, District>();
            CreateMap<MunicipalityUpdateDto, Municipality>();
        }
    }
}