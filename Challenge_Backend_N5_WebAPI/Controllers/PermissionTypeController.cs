using Challenge_Backend_N5_WebAPI.Application.Commands.RequestTypePermission;
using Challenge_Backend_N5_WebAPI.Application.Queries.GetPermissionType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge_Backend_N5_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PermissionTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<PermissionTypeController>
        [HttpGet]
        public async Task<IList<GetPermissionTypeQueryResponse>> Get()
        {
            return await _mediator.Send(new GetPermissionTypeQuery());
        }

        // POST api/<PermissionTypeController>
        [HttpPost]
        public async Task<RequestPermissionTypeResponse> Post([FromBody] RequestPermissionTypeCommand requestPermissionTypeCommand)
        {
            return await _mediator.Send(requestPermissionTypeCommand);
        }
    }
}
