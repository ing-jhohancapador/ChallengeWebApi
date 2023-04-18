using MediatR;

namespace Challenge_Backend_N5_WebAPI.Application.Commands.RequestPermission
{
    public class RequestPermissionCommand : IRequest<RequestPermissionResponse>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public long TypeId { get; set; }
    }
}
