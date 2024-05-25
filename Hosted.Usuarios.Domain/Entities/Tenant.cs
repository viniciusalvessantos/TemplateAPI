using Hosted.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Hosted.Usuarios.Domain.Entities {
    public class Tenant : BaseEntity {
        private Tenant() {

        }

        private Tenant(string name, bool isActive, bool isAssinaturaActive) {
            Name = name;
            IsActive = isActive;
            IsAssinaturaActive = isAssinaturaActive;
        }

        [MaxLength(60)]
        public string Name { get; private set; } = string.Empty;
        public bool IsAssinaturaActive { get; private set; }
        public bool IsActive { get; private set; }

        [MaxLength(10)]
        public virtual ICollection<ApplicationUser> Users { get; private set; } // Propriedade de navegação

        // Métodos para atualizar as propriedades
        public void UpdateName(string name) {
            if (!string.IsNullOrWhiteSpace(name) && name.Length <= 60) {
                Name = name;
            } else {
                throw new ArgumentException("Name is invalid.");
            }
        }

        public void UpdateIsAssinaturaActive(bool isAssinaturaActive) {
            IsAssinaturaActive = isAssinaturaActive;
        }

        public void UpdateIsActive(bool isActive) {
            IsActive = isActive;
        }

        public static Tenant New(string nome) {
            if (string.IsNullOrWhiteSpace(nome) && nome.Length > 60) {
                throw new ArgumentException("Name is invalid.");
            }
            return new Tenant(nome, true, false);
        }
    }
}
