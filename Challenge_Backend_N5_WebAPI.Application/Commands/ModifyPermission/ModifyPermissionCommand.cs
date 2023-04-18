using MediatR;

namespace Challenge_Backend_N5_WebAPI.Application.Commands.ModifyPermission
{
    public class ModifyPermissionCommand : IRequest<ModifyPermissionResponse>
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public long TypeId { get; set; }
    }
}
