using Hosted.Domain.Entities;

namespace Hosted.Usuarios.Domain.Entities {
    public class Tenant : BaseEntity {
        public Tenant() {

        }
        public Tenant(string name, bool isActive, ICollection<ApplicationUser> users) {
            Name = name;
            IsActive = isActive;
            Users = users;
        }

        public string Name { get; } = string.Empty;
        public bool IsActive { get; }

        public virtual ICollection<ApplicationUser> Users { get; } // Propriedade de navegação
    }
}
