using Hosted.Usuarios.Domain.Entities;
using Hosted.Usuarios.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Hosted.Usuarios.Application.Commands.Register {
    internal class RegisterUsuariosCommandHandler : IRequestHandler<RegisterUsuariosCommand> {
        private readonly UserManager<ApplicationUser> _userManager;
        public RegisterUsuariosCommandHandler(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task Handle(RegisterUsuariosCommand request, CancellationToken cancellationToken) {
            var identity = await _userManager.CreateAsync(new ApplicationUser(request.UserName, request.Name, request.Surname), request.Password);
            if (!identity.Succeeded)
                throw new RegisterException(identity.Errors);
        }
    }
}
