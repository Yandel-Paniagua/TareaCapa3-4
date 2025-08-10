using UnaApi2.Domain.Entities;

namespace UnaApi2.Infrastructure.Interfaces
{
    public interface IConsejosClimaticoRepository : IBaseRepository<ConsejosClimatico>
    {
        Task<List<ConsejosClimatico>> GetActiveAdviceAsync();



    }
}