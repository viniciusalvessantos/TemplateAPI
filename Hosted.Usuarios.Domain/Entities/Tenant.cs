using Hosted.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hosted.Usuarios.Domain.Entities {
    public class Tenant : BaseEntity {
        private Tenant() {

        }
        private Tenant(string nome, string telefone, string email, string cnpj) {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Cnpj = cnpj;
            IsActive = true;
        }

        [MaxLength(60)]
        public string Nome { get; private set; } = string.Empty;

        [MaxLength(11)]
        public string Telefone { get; private set; } = string.Empty;

        [EmailAddress]
        public string Email { get; private set; }
        [MaxLength(14)]
        public string Cnpj { get; private set; }

        public bool IsActive { get; private set; }

        [MaxLength(10)]
        public virtual ICollection<ApplicationUser> Users { get; private set; } // Propriedade de navegação

        [ForeignKey("RedeTenantTenant")]
        public Guid? RedeId { get; private set; }
        public virtual RedeTenant RedeTenantTenant { get; private set; }

        // Métodos para atualizar as propriedades
        public void UpdateName(string name) {
            if (!string.IsNullOrWhiteSpace(name) && name.Length <= 60) {
                Nome = name;
            } else {
                throw new ArgumentException("Name is invalid.");
            }
        }
        public void UpdateIsActive(bool isActive) {
            IsActive = isActive;
        }

        public static Tenant New(string nome, string telefone, string email, string cnpj) {
            if (string.IsNullOrWhiteSpace(nome) && nome.Length > 60) {
                throw new ArgumentException("Name is invalid.");
            }
            return new Tenant(nome, telefone, email, cnpj);
        }
    }
}
