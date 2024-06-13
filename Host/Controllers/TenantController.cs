using Hosted.Infrastructure.Exceptions;
using Hosted.Usuarios.Application.Commands.Register.Tenants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hosted.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : BaseController {
        private readonly IMediator _mediator;
        public TenantController(IMediator mediator) {
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        //[RequireTenantId(true)]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterTenantCommand request) =>
            Ok(await _mediator.Send(request));
    }
}
