using Microsoft.AspNetCore.Identity;

namespace Hosted.Usuarios.Domain.Entities {
    public class ApplicationUser : IdentityUser {

        public ApplicationUser(string userName, string name, string surname) : base(userName) {
            Name = name;
            Surname = surname;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
