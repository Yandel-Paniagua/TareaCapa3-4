using AutoMapper;
using UnaApi2.Application.Contracts;
using UnaApi2.Application.Core;
using UnaApi2.Application.DTOs;
using UnaApi2.Domain.Entities;
using UnaApi2.Infrastructure.Interfaces;

namespace UnaApi2.Application.Services
{
    public class MunicipalityService : BaseService<Municipality, MunicipalityReadDto, MunicipalityCreateDto, MunicipalityUpdateDto>, IMunicipalityService
    {
        private readonly IMunicipalityRepository _municipalityRepository;

        
        public MunicipalityService(IMunicipalityRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _municipalityRepository = repository;
        }
        
    }
}