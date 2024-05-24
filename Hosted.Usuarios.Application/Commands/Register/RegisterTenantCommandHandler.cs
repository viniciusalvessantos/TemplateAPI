using Hosted.Usuarios.Application.Responses.TenantResponses;
using MediatR;

namespace Hosted.Usuarios.Application.Commands.Register {
    public class RegisterTenantCommandHandler : IRequestHandler<RegisterTenantCommand, RegisterResponser> {



        public Task<RegisterResponser> Handle(RegisterTenantCommand request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}
