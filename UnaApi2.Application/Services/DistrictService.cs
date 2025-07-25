using AutoMapper;
using UnaApi2.Application.Contracts;
using UnaApi2.Application.Core;
using UnaApi2.Application.DTOs;
using UnaApi2.Domain.Entities;
using UnaApi2.Infrastructure.Interfaces;

namespace UnaApi2.Application.Services
{
    public class DistrictService : BaseService<District, DistrictReadDto, DistrictCreateDto, DistrictUpdateDto>, IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        
        public DistrictService(IDistrictRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _districtRepository = repository;
        }
        
    }
}