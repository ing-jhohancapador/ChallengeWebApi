using Challenge_Backend_N5_WebAPI.Domain.Aggregates;
using Challenge_Backend_N5_WebAPI.Domain.Repositories;
using Challenge_Backend_N5_WebAPI.Infrastructure.Context;

namespace Challenge_Backend_N5_WebAPI.Infrastructure.Repositories
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(DbContextChallengeN5 dbContext) : base(dbContext)
        {
        }
    }
}
