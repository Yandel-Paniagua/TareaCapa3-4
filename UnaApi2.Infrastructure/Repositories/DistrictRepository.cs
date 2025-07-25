using UnaApi2.Domain.Entities;
using UnaApi2.Infrastructure.Context;
using UnaApi2.Infrastructure.Core;
using UnaApi2.Infrastructure.Interfaces;

namespace UnaApi2.Infrastructure.Repositories
{
    public class DistrictRepository : BaseRepository<District>, IDistrictRepository
    {
        public DistrictRepository(UnaApiDbContext context) : base(context)
        {
        }
        
    }
}