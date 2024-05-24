using Hosted.Usuarios.Application.Responses.TenantResponses;
using MediatR;

namespace Hosted.Usuarios.Application.Commands.Register {
    public class RegisterTenantCommand : IRequest<RegisterResponser> {
        public RegisterTenantCommand(string name, bool isActive, bool isAssinaturaActive) {
            Name = name;
            IsActive = isActive;
            IsAssinaturaActive = isAssinaturaActive;
        }
        public string Name { get; }
        public bool IsActive { get; }
        public bool IsAssinaturaActive { get; }


    }
}
