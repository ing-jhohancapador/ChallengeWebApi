using MediatR;

namespace Challenge_Backend_N5_WebAPI.Application.Commands.RequestTypePermission
{
    public class RequestPermissionTypeCommand : IRequest<RequestPermissionTypeResponse>
    {
        public string? Description { get; set; }
    }
}
