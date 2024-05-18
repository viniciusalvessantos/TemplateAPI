using Hosted.Infrastructure.Exceptions;
using Hosted.Usuarios.Application.Commands.Register;
using Hosted.Usuarios.Application.Queries.Login;
using Hosted.Usuarios.Application.Responses.LoginResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hosted.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : BaseController {
        private readonly IMediator _mediator;
        public UsuariosController(IMediator mediator) {
            _mediator = mediator;
        }
        /// <summary>
        /// Login using username and password
        /// </summary>
        /// <param name="request">Login request parameter</param>
        /// <returns>JWT Token</returns>
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> LogIn(LoginQuery request)
            => Ok(await _mediator.Send(request));

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="request">Login request parameter</param>
        /// <returns>JWT Token</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterUsuariosCommand request) =>
            Ok(await _mediator.Send(request));
    }
}
