using MediatR;

namespace Challenge_Backend_N5_WebAPI.Application.Queries.GetPermissionsById
{
    public class GetPermissionsByIdQuery : IRequest<GetPermissionsByIdQueryResponse>
    {
        public long Id { get; set; }
    }
}
