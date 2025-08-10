using UnaApi2.Application.DTOs;
// declaral el metodo en el Interface del service
namespace UnaApi2.Application.Contracts
{
    public interface ILecturasClimaticaService : IBaseService<LecturasClimaticaReadDto, LecturasClimaticaCreateDto, LecturasClimaticaUpdateDto>
    {
        
        Task<LecturasClimaticaReadDto> GetLastReadingAsync();
        Task<List<LecturasClimaticaReadDto>> GetAllActiveLecturasAsync();

       
    }

   
}