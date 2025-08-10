using AutoMapper;
using UnaApi2.Application.Contracts;
using UnaApi2.Application.Core;
using UnaApi2.Application.DTOs;
using UnaApi2.Domain.Entities;
using UnaApi2.Infrastructure.Interfaces;

namespace UnaApi2.Application.Services
{
    public class LecturasClimaticaService : BaseService<LecturasClimatica, LecturasClimaticaReadDto, LecturasClimaticaCreateDto, LecturasClimaticaUpdateDto>, ILecturasClimaticaService
    {
        private readonly ILecturasClimaticaRepository _lecturasclimaticaRepository;

        public LecturasClimaticaService(ILecturasClimaticaRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _lecturasclimaticaRepository = repository;
        }
        //declaral el metodo en el interface del repository
        public async Task<List<LecturasClimaticaReadDto>> GetAllActiveLecturasAsync()
        {
            var lecturas = await _lecturasclimaticaRepository.GetAllActiveLecturasAsync();
            return _mapper.Map<List<LecturasClimaticaReadDto>>(lecturas);
        }


        public async Task<LecturasClimaticaReadDto> GetLastReadingAsync()
        {
            var ultimalectura = await _lecturasclimaticaRepository.GetLastReadingAsync();

            return _mapper.Map<LecturasClimaticaReadDto>(ultimalectura);
        }
    }
}