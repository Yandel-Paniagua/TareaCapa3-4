using UnaApi2.Domain.Entities;

namespace UnaApi2.Infrastructure.Interfaces
{
    public interface ILecturasClimaticaRepository : IBaseRepository<LecturasClimatica>
    {
        
        Task<List<LecturasClimatica>> GetAllActiveLecturasAsync();
        Task<LecturasClimatica> GetLastReadingAsync();

    }
}