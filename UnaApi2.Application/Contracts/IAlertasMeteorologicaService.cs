using UnaApi2.Application.DTOs;


namespace UnaApi2.Application.Contracts
{
    public interface IAlertasMeteorologicaService : IBaseService<AlertasMeteorologicaReadDto, AlertasMeteorologicaCreateDto, AlertasMeteorologicaUpdateDto>
    {
        Task<List<AlertasMeteorologicaReadDto>> GetActiveAlertsAsync();
     
    }
}