namespace Hosted.Usuarios.Application.Responses.TenantResponses {
    public class RegisterResponser {
        public RegisterResponser(Guid tenantId) {
            TenantId = tenantId;
        }

        public Guid TenantId { get; }
    }
}
