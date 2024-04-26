using Hosted.Usuarios.Application.Responses.RegisterResponser;
using Hosted.Usuarios.Domain.Entities;
using Hosted.Usuarios.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Hosted.Usuarios.Application.Commands.Register {
    public class RegisterUsuariosCommandHandler : IRequestHandler<RegisterUsuariosCommand, RegisterResponser> {
        private readonly UserManager<ApplicationUser> _userManager;
        public RegisterUsuariosCommandHandler(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<RegisterResponser> Handle(RegisterUsuariosCommand request, CancellationToken cancellationToken) {
            var identity = await _userManager.CreateAsync(new ApplicationUser(request.UserName, request.Name, request.Surname), request.Password);
            if (!identity.Succeeded)
                throw new RegisterException(identity.Errors);

            return new RegisterResponser("Cadastrado com sucesso!!");
        }
    }
}
