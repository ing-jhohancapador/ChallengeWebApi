using Challenge_Backend_N5_WebAPI.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;


namespace Challenge_Backend_N5_WebAPI.Infrastructure.Context
{
    public class DbContextChallengeN5 : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PermissionType> Type { get; set; }

        public DbContextChallengeN5(DbContextOptions<DbContextChallengeN5> options) : base(options) { }

    }
}
