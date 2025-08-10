using UnaApi2.Application.DTOs;
//
//declaral el metodo en el Interface del service 
namespace UnaApi2.Application.Contracts
{
    public interface IConsejosClimaticoService : IBaseService<ConsejosClimaticoReadDto, ConsejosClimaticoCreateDto, ConsejosClimaticoUpdateDto>
    {
        Task<List<ConsejosClimaticoReadDto>> GetAllActiveConsejosAsync();
    }
}