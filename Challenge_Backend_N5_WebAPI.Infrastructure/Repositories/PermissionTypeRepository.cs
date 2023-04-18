using Challenge_Backend_N5_WebAPI.Domain.Aggregates;
using Challenge_Backend_N5_WebAPI.Domain.Repositories;
using Challenge_Backend_N5_WebAPI.Infrastructure.Context;

namespace Challenge_Backend_N5_WebAPI.Infrastructure.Repositories
{
    public class PermissionTypeRepository : GenericRepository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(DbContextChallengeN5 dbContext) : base(dbContext)
        {
        }
    }
}
