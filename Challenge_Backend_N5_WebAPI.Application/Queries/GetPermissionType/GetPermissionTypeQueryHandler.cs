using Challenge_Backend_N5_WebAPI.Domain.UnitOfWork;
using Challenge_Backend_N5_WebAPI.Domain.ValueObjects;
using SlimMessageBus;

namespace Challenge_Backend_N5_WebAPI.Application.Queries.GetPermissionType
{
    public class GetPermissionTypeQueryHandler : MediatR.IRequestHandler<GetPermissionTypeQuery, IList<GetPermissionTypeQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageBus _messageBus;

        public GetPermissionTypeQueryHandler(IUnitOfWork unitOfWork, IMessageBus messageBus)
        {
            _unitOfWork = unitOfWork;
            _messageBus = messageBus;
        }

        public async Task<IList<GetPermissionTypeQueryResponse>> Handle(GetPermissionTypeQuery request, CancellationToken cancellationToken)
        {
            var lista = await _unitOfWork.PermissionsTypeRepository.GetAllAsync(cancellationToken);
            await _messageBus.Publish(new StructureKafka { Id = Guid.NewGuid(), NameOperacion = "get_PType" }, cancellationToken: cancellationToken);
            return lista.Select(x => new GetPermissionTypeQueryResponse
            {
                Id = x.Id,
                Description = x.Description,

            }).ToList();


        }
    }
}
