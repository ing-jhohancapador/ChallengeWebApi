using Challenge_Backend_N5_WebAPI.Application.Commands.ModifyPermission;
using Challenge_Backend_N5_WebAPI.Application.Commands.RequestPermission;
using Challenge_Backend_N5_WebAPI.Application.Queries.GetPermissions;
using Challenge_Backend_N5_WebAPI.Application.Queries.GetPermissionsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge_Backend_N5_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PermissionController>/GetPermissions
        [HttpGet("GetPermissions")]
        public async Task<IList<GetPermissionsQueryResponse>> Get()
        {
            return await _mediator.Send(new GetPermissionsQuery());
        }

        // GET api/<PermissionController>/GetPermissions/5
        [HttpGet("GetPermissions/{id}")]
        public async Task<GetPermissionsByIdQueryResponse> Get(int id)
        {
            return await _mediator.Send(new GetPermissionsByIdQuery { Id = id });
        }

        // POST api/<PermissionController>/RequestPermission
        [HttpPost("RequestPermission")]
        public async Task<RequestPermissionResponse> Post([FromBody] RequestPermissionCommand request)
        {
            return await _mediator.Send(request);
        }

        // PUT api/<PermissionController>/ModifyPermission/5
        [HttpPut("ModifyPermission/{id}")]
        public async Task<ModifyPermissionResponse> Put(int id, [FromBody] ModifyPermissionCommand request)
        {
            request.Id = id;
            return await _mediator.Send(request);
        }
    }
}
