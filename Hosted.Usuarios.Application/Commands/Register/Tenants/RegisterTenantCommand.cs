using Hosted.Usuarios.Application.Responses.TenantResponses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Hosted.Usuarios.Application.Commands.Register.Tenants
{
    public class RegisterTenantCommand : IRequest<RegisterResponser>
    {


        public RegisterTenantCommand(string nome, string telefone, string email, string cnpj)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Cnpj = cnpj;
        }

        [MaxLength(60)]
        public string Nome { get; private set; } = string.Empty;

        [MaxLength(11)]
        public string Telefone { get; private set; } = string.Empty;

        [EmailAddress]
        public string Email { get; private set; }
        [MaxLength(14)]
        public string Cnpj { get; private set; }



    }
}
