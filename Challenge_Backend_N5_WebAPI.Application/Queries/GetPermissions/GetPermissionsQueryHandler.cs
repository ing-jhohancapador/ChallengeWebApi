using Challenge_Backend_N5_WebAPI.Domain.UnitOfWork;
using Challenge_Backend_N5_WebAPI.Domain.ValueObjects;
using SlimMessageBus;
using System.Security.Cryptography.X509Certificates;

namespace Challenge_Backend_N5_WebAPI.Application.Queries.GetPermissions
{
    public class GetPermissionsQueryHandler : MediatR.IRequestHandler<GetPermissionsQuery, IList<GetPermissionsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageBus _messageBus;

        public GetPermissionsQueryHandler(IUnitOfWork unitOfWork, IMessageBus messageBus)
        {
            _unitOfWork = unitOfWork;
            _messageBus = messageBus;
        }

        public async Task<IList<GetPermissionsQueryResponse>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            var lista = await _unitOfWork.PermissionsRepository.GetAllAsync(cancellationToken);
            await _messageBus.Publish(new StructureKafka { Id = Guid.NewGuid(), NameOperacion = "get" }, cancellationToken: cancellationToken);
            return lista.Select(x => new GetPermissionsQueryResponse
            {
                Id = x.Id,
                NombreEmpleado = x.FirstName,
                ApellidoEmpleado = x.LastName,
                FechaPermiso = x.DateOfPermission,
                TypeId = x.TypeId,

            }).ToList();


        }
    }
}
