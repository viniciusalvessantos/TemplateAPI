using Hosted.Usuarios.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hosted.Usuarios.Infrastructure {
    public class UsuariosDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string> {
        public UsuariosDbContext(DbContextOptions<UsuariosDbContext> options) : base(options) {
        }
    }
}
