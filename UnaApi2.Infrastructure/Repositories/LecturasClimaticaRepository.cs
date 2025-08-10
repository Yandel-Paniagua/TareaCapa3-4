using Microsoft.EntityFrameworkCore;
using UnaApi2.Domain.Entities;
using UnaApi2.Infrastructure.Context;
using UnaApi2.Infrastructure.Core;
using UnaApi2.Infrastructure.Interfaces;
//imnpolementar el metodo en el repository
namespace UnaApi2.Infrastructure.Repositories
{
    public class LecturasClimaticaRepository : BaseRepository<LecturasClimatica>, ILecturasClimaticaRepository
    {
        public LecturasClimaticaRepository(UnaApiDbContext context) : base(context)
        {
        }

        public async Task<List<LecturasClimatica>> GetAllActiveLecturasAsync()
        {
            return await _context.LecturasClimaticas.ToListAsync();
        }

        public async Task<LecturasClimatica> GetLastReadingAsync()
        {
            return await _context.LecturasClimaticas
                .OrderByDescending(l => l.LecturaId)
                .FirstOrDefaultAsync();
        }
    }
}