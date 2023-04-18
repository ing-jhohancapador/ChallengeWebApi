using Challenge_Backend_N5_WebAPI.Domain.Repositories;
using Challenge_Backend_N5_WebAPI.Domain.UnitOfWork;
using Challenge_Backend_N5_WebAPI.Infrastructure.Context;
using Challenge_Backend_N5_WebAPI.Infrastructure.Repositories;


namespace Challenge_Backend_N5_WebAPI.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextChallengeN5 _dbContext;
        private IPermissionRepository _permissionRepository;
        private IPermissionTypeRepository _permissionTypeRepository;

        public UnitOfWork(DbContextChallengeN5 dbContext)
        {
            _dbContext = dbContext;
        }

        public IPermissionRepository PermissionsRepository
        {
            get { return _permissionRepository = _permissionRepository ?? new PermissionRepository(_dbContext); }
        }

        public IPermissionTypeRepository PermissionsTypeRepository
        {
            get { return _permissionTypeRepository = _permissionTypeRepository ?? new PermissionTypeRepository(_dbContext); }
        }

        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
