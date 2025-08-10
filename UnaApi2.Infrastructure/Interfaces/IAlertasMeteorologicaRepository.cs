using UnaApi2.Domain.Entities;

namespace UnaApi2.Infrastructure.Interfaces
{
    public interface IAlertasMeteorologicaRepository : IBaseRepository<AlertasMeteorologica>
    {
        Task<IEnumerable<AlertasMeteorologica>> GetActiveAlertsAsync();
        
    }
}