using AutoMapper;
using UnaApi2.Application.Contracts;
using UnaApi2.Application.Core;
using UnaApi2.Application.DTOs;
using UnaApi2.Domain.Entities;
using UnaApi2.Infrastructure.Interfaces;
//implementar el metodo en el service
namespace UnaApi2.Application.Services
{
    public class AlertasMeteorologicaService : BaseService<AlertasMeteorologica, AlertasMeteorologicaReadDto, AlertasMeteorologicaCreateDto, AlertasMeteorologicaUpdateDto>, IAlertasMeteorologicaService
    {
        private readonly IAlertasMeteorologicaRepository _alertasmeteorologicaRepository;
        
        public AlertasMeteorologicaService(IAlertasMeteorologicaRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _alertasmeteorologicaRepository = repository;
        }

        public async Task<List<AlertasMeteorologicaReadDto>> GetActiveAlertsAsync()
        {
            var activeAlerts = await _alertasmeteorologicaRepository.GetActiveAlertsAsync();
            return _mapper.Map<List<AlertasMeteorologicaReadDto>>(activeAlerts);

        }   
    }
}