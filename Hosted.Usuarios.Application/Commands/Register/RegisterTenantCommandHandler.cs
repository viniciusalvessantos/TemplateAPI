
using Hosted.Usuarios.Application.Responses.TenantResponses;
using Hosted.Usuarios.Domain.Entities;
using Hosted.Usuarios.Domain.Repository;
using MediatR;

namespace Hosted.Usuarios.Application.Commands.Register {
    public class RegisterTenantCommandHandler : IRequestHandler<RegisterTenantCommand, RegisterResponser> {
        //private readonly ITenantEventBus _tenantEventBus;
        private readonly ITenantRepository _tenantRepository;
        public RegisterTenantCommandHandler(ITenantRepository tenantRepository) {
            //_tenantEventBus = tenantEventBus;
            _tenantRepository = tenantRepository;
        }


        public async Task<RegisterResponser> Handle(RegisterTenantCommand request, CancellationToken cancellationToken) {

            var tenant = Tenant.New(request.Name);

            await _tenantRepository.Add(tenant);

            //await _tenantEventBus.Publish();

            await _tenantRepository.CommitAsync();
            return new RegisterResponser(tenant.Id);

        }
    }
}
