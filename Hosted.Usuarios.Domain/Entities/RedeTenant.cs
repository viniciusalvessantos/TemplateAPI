using Hosted.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Hosted.Usuarios.Domain.Entities {
    public class RedeTenant : BaseEntity {

        private RedeTenant(string nome) {
            Nome = nome;
        }

        public string Nome { get; private set; }

        public void UpdateNome(string nome) {
            Nome = nome;
        }

        [MaxLength(100)]
        public virtual ICollection<Tenant> Tenants { get; private set; } // Propriedade de navegação

        public static RedeTenant New(string nome) {
            if (string.IsNullOrWhiteSpace(nome) && nome.Length > 60) {
                throw new ArgumentException("Name is invalid.");
            }
            return new RedeTenant(nome);
        }
    }
}
