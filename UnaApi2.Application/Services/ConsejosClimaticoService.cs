using AutoMapper;
using UnaApi2.Application.Contracts;
using UnaApi2.Application.Core;
using UnaApi2.Application.DTOs;
using UnaApi2.Domain.Entities;
using UnaApi2.Infrastructure.Interfaces;

namespace UnaApi2.Application.Services
{
    public class ConsejosClimaticoService : BaseService<ConsejosClimatico, ConsejosClimaticoReadDto, ConsejosClimaticoCreateDto, ConsejosClimaticoUpdateDto>, IConsejosClimaticoService
    {
        private readonly IConsejosClimaticoRepository _consejosclimaticoRepository;
        
        public ConsejosClimaticoService(IConsejosClimaticoRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _consejosclimaticoRepository = repository;
        }

       

        public async Task<List<ConsejosClimaticoReadDto>> GetAllActiveConsejosAsync()
        {
            var activeConsejos = await _consejosclimaticoRepository.GetActiveAdviceAsync();
            return _mapper.Map<List<ConsejosClimaticoReadDto>>(activeConsejos);
        }
    }

}