using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hosted.Usuarios.Domain.Entities {
    public class ApplicationUser : IdentityUser {

        private ApplicationUser() {
        }
        private ApplicationUser(string userName, string nome, string sobrenome, Guid tenantId) : base(userName) {
            Nome = nome;
            SobreNome = sobrenome;
            TenantId = tenantId;
        }
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string Foto { get; private set; }
        [ForeignKey("Tenant")]
        public Guid? TenantId { get; private set; }
        public void UpdateNome(string nome) {
            Nome = nome;
        }
        public void UpdateSobrenome(string sobrenome) {
            SobreNome = sobrenome;
        }
        public void UpdateFoto(string urlfoto) {
            Foto = urlfoto;
        }

        public void UpdateTenantId(Guid tenantId) {
            TenantId = tenantId;
        }



        public virtual Tenant Tenant { get; private set; }

        public static ApplicationUser New(string userName, string name, string surname, Guid tenantId) {

            return new ApplicationUser(userName, name, surname, tenantId);
        }
    }
}
