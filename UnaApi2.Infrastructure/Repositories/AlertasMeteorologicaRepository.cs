using Microsoft.EntityFrameworkCore;
using UnaApi2.Domain.Entities;
using UnaApi2.Infrastructure.Context;
using UnaApi2.Infrastructure.Core;
using UnaApi2.Infrastructure.Interfaces;

namespace UnaApi2.Infrastructure.Repositories
{
    public class AlertasMeteorologicaRepository : BaseRepository<AlertasMeteorologica>, IAlertasMeteorologicaRepository
    {
        public AlertasMeteorologicaRepository(UnaApiDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AlertasMeteorologica>> GetActiveAlertsAsync()
        {
            return await _context.AlertasMeteorologicas.ToListAsync();


        }
    }
}