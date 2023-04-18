using Challenge_Backend_N5_WebAPI.Domain.Aggregates;
using Challenge_Backend_N5_WebAPI.Domain.UnitOfWork;
using Challenge_Backend_N5_WebAPI.Domain.ValueObjects;
using SlimMessageBus;

namespace Challenge_Backend_N5_WebAPI.Application.Commands.ModifyPermission
{
    public class ModifyPermissionCommandHandler : MediatR.IRequestHandler<ModifyPermissionCommand, ModifyPermissionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageBus _messageBus;

        public ModifyPermissionCommandHandler(IUnitOfWork unitOfWork, IMessageBus messageBus)
        {
            _unitOfWork = unitOfWork;
            _messageBus = messageBus;
        }

        public async Task<ModifyPermissionResponse> Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permission
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfPermission = System.DateTime.Now,
                TypeId = request.TypeId,
            };

            _unitOfWork.PermissionsRepository.Update(permission);
            await _unitOfWork.CommitAsync();
            await _messageBus.Publish(new StructureKafka { Id = Guid.NewGuid(), NameOperacion = "modify" }, cancellationToken: cancellationToken);
            return new ModifyPermissionResponse { Message = $"Se actualiza permiso con el id: {permission.Id}" };
        }

    }
}
