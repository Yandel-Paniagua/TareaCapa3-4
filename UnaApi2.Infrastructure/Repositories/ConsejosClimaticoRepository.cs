using Microsoft.EntityFrameworkCore;
using UnaApi2.Domain.Entities;
using UnaApi2.Infrastructure.Context;
using UnaApi2.Infrastructure.Core;
using UnaApi2.Infrastructure.Interfaces;
//declaral el metodo en el interface del repository
namespace UnaApi2.Infrastructure.Repositories
{
    public class ConsejosClimaticoRepository : BaseRepository<ConsejosClimatico>, IConsejosClimaticoRepository
    {
        public ConsejosClimaticoRepository(UnaApiDbContext context) : base(context)
        {
        }

        public async Task<List<ConsejosClimatico>> GetActiveAdviceAsync()
        {
            return await _context.ConsejosClimaticos.ToListAsync();
        }
    }
}