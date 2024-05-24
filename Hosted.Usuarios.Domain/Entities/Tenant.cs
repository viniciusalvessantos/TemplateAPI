using Hosted.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Hosted.Usuarios.Domain.Entities {
    public class Tenant : BaseEntity {
        public Tenant() {

        }
        public Tenant(string name, bool isActive, bool isAssinaturaActive) {
            Name = name;
            IsActive = isActive;
            IsAssinaturaActive = isAssinaturaActive;
        }

        [MaxLength(60)]
        public string Name { get; } = string.Empty;
        public bool IsAssinaturaActive { get; }
        public bool IsActive { get; }

        [MaxLength(10)]
        public virtual ICollection<ApplicationUser> Users { get; } // Propriedade de navegação
    }
}
