using Challenge_Backend_N5_WebAPI.Domain.Aggregates;
using Challenge_Backend_N5_WebAPI.Domain.UnitOfWork;
using Challenge_Backend_N5_WebAPI.Domain.ValueObjects;
using SlimMessageBus;

namespace Challenge_Backend_N5_WebAPI.Application.Commands.RequestPermission
{
    public class RequestPermissionCommandHandler : MediatR.IRequestHandler<RequestPermissionCommand, RequestPermissionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageBus _messageBus;

        public RequestPermissionCommandHandler(IUnitOfWork unitOfWork, IMessageBus messageBus)
        {
            _unitOfWork = unitOfWork;
            _messageBus = messageBus;
        }

        public async Task<RequestPermissionResponse> Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permission
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfPermission = System.DateTime.Now,
                TypeId = request.TypeId,
            };

            _unitOfWork.PermissionsRepository.Add(permission);
            await _unitOfWork.CommitAsync();

            await _messageBus.Publish(new StructureKafka { Id = Guid.NewGuid(), NameOperacion = "request" }, cancellationToken: cancellationToken);
            return new RequestPermissionResponse { Message = $"Se crea un nuevo permiso con el id: {permission.Id}" };
        }

    }
}
