using Hosted.Usuarios.Application.Responses.TenantResponses;
using Hosted.Usuarios.Domain.Entities;
using Hosted.Usuarios.Domain.Repository;
using MediatR;

namespace Hosted.Usuarios.Application.Commands.Register.Tenants
{
    public class RegisterTenantCommandHandler : IRequestHandler<RegisterTenantCommand, RegisterResponser>
    {
        private readonly ITenantRepository _tenantRepository;
        public RegisterTenantCommandHandler(ITenantRepository tenantRepository)
        {

            _tenantRepository = tenantRepository;
        }


        public async Task<RegisterResponser> Handle(RegisterTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = Tenant.New(request.Nome, request.Telefone, request.Email, request.Cnpj);
            await _tenantRepository.Add(tenant);
            await _tenantRepository.CommitAsync();
            return new RegisterResponser(tenant.Id);

        }
    }
}
