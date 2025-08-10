using AutoMapper;
using UnaApi2.Application.DTOs;
using UnaApi2.Domain.Entities;

namespace UnaApi2.Application.Mapping
{
    public class AlertasMeteorologicaProfile : Profile
    {
        public AlertasMeteorologicaProfile()
        {
            CreateMap<AlertasMeteorologica, AlertasMeteorologicaReadDto>();
            
            CreateMap<AlertasMeteorologicaCreateDto, AlertasMeteorologica>();
            
            CreateMap<AlertasMeteorologicaUpdateDto, AlertasMeteorologica>();
        }
    }
}