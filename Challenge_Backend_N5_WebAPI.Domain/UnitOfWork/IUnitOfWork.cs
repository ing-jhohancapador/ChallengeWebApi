using Challenge_Backend_N5_WebAPI.Domain.Repositories;

namespace Challenge_Backend_N5_WebAPI.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPermissionRepository PermissionsRepository { get; }
        IPermissionTypeRepository PermissionsTypeRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
