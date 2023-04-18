using Challenge_Backend_N5_WebAPI.Domain.Aggregates;
using Challenge_Backend_N5_WebAPI.Domain.UnitOfWork;
using Challenge_Backend_N5_WebAPI.Domain.ValueObjects;
using SlimMessageBus;

namespace Challenge_Backend_N5_WebAPI.Application.Commands.RequestTypePermission
{
    public class RequestPermissionTypeCommandHandler : MediatR.IRequestHandler<RequestPermissionTypeCommand, RequestPermissionTypeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageBus _messageBus;

        public RequestPermissionTypeCommandHandler(IUnitOfWork unitOfWork, IMessageBus messageBus)
        {
            _unitOfWork = unitOfWork;
            _messageBus = messageBus;
        }

        public async Task<RequestPermissionTypeResponse> Handle(RequestPermissionTypeCommand request, CancellationToken cancellationToken)
        {
            var permissionType = new PermissionType
            {
                Description = request.Description,
            };

            _unitOfWork.PermissionsTypeRepository.Add(permissionType);
            await _unitOfWork.CommitAsync();

            await _messageBus.Publish(new StructureKafka { Id = Guid.NewGuid(), NameOperacion = "request_Ptype" }, cancellationToken: cancellationToken);
            return new RequestPermissionTypeResponse { Message = $"Se crea un nuevo tipo permiso con el id: {permissionType.Id}" };
        }

    }
}
