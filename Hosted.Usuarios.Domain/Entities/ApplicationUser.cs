using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hosted.Usuarios.Domain.Entities {
    public class ApplicationUser : IdentityUser {

        private ApplicationUser() {
        }
        private ApplicationUser(string userName, string name, string surname, Guid tenantId) : base(userName) {
            Name = name;
            Surname = surname;
            TenantId = tenantId;

        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        [ForeignKey("Tenant")]
        public Guid? TenantId { get; private set; }
        public virtual Tenant Tenant { get; private set; }

        public static ApplicationUser New(string userName, string name, string surname, Guid tenantId) {

            return new ApplicationUser(userName, name, surname, tenantId);
        }
    }
}
