using AutoMapper;
using UnaApi2.Application.DTOs;
using UnaApi2.Domain.Entities;

namespace UnaApi2.Application.Mapping
{
    public class ConsejosClimaticoProfile : Profile
    {
        public ConsejosClimaticoProfile()
        {
            CreateMap<ConsejosClimatico, ConsejosClimaticoReadDto>();
            
            CreateMap<ConsejosClimaticoCreateDto, ConsejosClimatico>();
            
            CreateMap<ConsejosClimaticoUpdateDto, ConsejosClimatico>();
        }
    }
}