using Challenge_Backend_N5_WebAPI.Domain.UnitOfWork;
using Challenge_Backend_N5_WebAPI.Domain.ValueObjects;
using SlimMessageBus;

namespace Challenge_Backend_N5_WebAPI.Application.Queries.GetPermissionsById
{
    public class GetPermissionsByIdQueryHandler : MediatR.IRequestHandler<GetPermissionsByIdQuery, GetPermissionsByIdQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageBus _messageBus;

        public GetPermissionsByIdQueryHandler(IUnitOfWork unitOfWork, IMessageBus messageBus)
        {
            _unitOfWork = unitOfWork;
            _messageBus = messageBus;
        }

        public async Task<GetPermissionsByIdQueryResponse> Handle(GetPermissionsByIdQuery request, CancellationToken cancellationToken)
        {
            var lista = await _unitOfWork.PermissionsRepository.GetAsync(t => t.Id == request.Id, cancellationToken);

            var response = new GetPermissionsByIdQueryResponse
            {
                Id = lista.Id,
                NombreEmpleado = lista.FirstName,
                ApellidoEmpleado = lista.LastName,
                FechaPermiso = lista.DateOfPermission,
                TypeId = lista.TypeId,

            };
            await _messageBus.Publish(new StructureKafka { Id = Guid.NewGuid(), NameOperacion = "getById" }, cancellationToken: cancellationToken);
            return response;

        }
    }
}
