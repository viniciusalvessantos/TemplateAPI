using Hosted.Usuarios.Application.Responses.RegisterResponser;
using MediatR;

namespace Hosted.Usuarios.Application.Commands.Register.Usuarios
{
    public class RegisterUsuariosCommand : IRequest<RegisterResponser>
    {
        public RegisterUsuariosCommand(string userName, string password, string name, string surname, Guid tenantId)
        {
            UserName = userName;
            Password = password;
            Name = name;
            Surname = surname;
            TenantId = tenantId;
        }

        public string UserName { get; }
        public string Password { get; }
        public string Name { get; }
        public string Surname { get; }

        public Guid TenantId { get; }
    }
}
