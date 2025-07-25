using AutoMapper;
using UnaApi2.Application.DTOs;
using UnaApi2.Domain.Entities;

namespace UnaApi2.Application.Mapping
{
    public class DistrictProfile : Profile
    {
        public DistrictProfile()
        {
            CreateMap<District, DistrictReadDto>();
            
            CreateMap<DistrictCreateDto, District>();
            
            CreateMap<DistrictUpdateDto, District>();
        }
    }
}