using AutoMapper;
        using UnaApi2.Application.DTOs;
        using UnaApi2.Domain.Entities;


namespace UnaApi2.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AlertasMeteorologica, AlertasMeteorologicaReadDto>();
            CreateMap<ConsejosClimatico, ConsejosClimaticoReadDto>();
            CreateMap<LecturasClimatica, LecturasClimaticaReadDto>();
            CreateMap<AlertasMeteorologicaCreateDto, AlertasMeteorologica>();
            CreateMap<ConsejosClimaticoCreateDto, ConsejosClimatico>();
            CreateMap<LecturasClimaticaCreateDto, LecturasClimatica>();
            CreateMap<AlertasMeteorologicaUpdateDto, AlertasMeteorologica>();
            CreateMap<ConsejosClimaticoUpdateDto, ConsejosClimatico>();
            CreateMap<LecturasClimaticaUpdateDto, LecturasClimatica>();
        }
    }
}