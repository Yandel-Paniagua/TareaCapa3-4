using UnaApi2.Domain.Entities;
using UnaApi2.Infrastructure.Context;
using UnaApi2.Infrastructure.Core;
using UnaApi2.Infrastructure.Interfaces;

namespace UnaApi2.Infrastructure.Repositories
{
    public class MunicipalityRepository : BaseRepository<Municipality>, IMunicipalityRepository
    {
        public MunicipalityRepository(UnaApiDbContext context) : base(context)
        {
        }
        
    }
}