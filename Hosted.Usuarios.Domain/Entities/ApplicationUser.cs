using Microsoft.AspNetCore.Identity;

namespace Hosted.Usuarios.Domain.Entities {
    public class ApplicationUser : IdentityUser {

        public ApplicationUser() {
        }
        public ApplicationUser(string userName, string name, string surname, Guid tenantId) : base(userName) {
            Name = name;
            Surname = surname;
            TenantId = tenantId;

        }
        public string Name { get; }
        public string Surname { get; }

        public Guid? TenantId { get; }
        public virtual Tenant Tenant { get; }
    }
}
