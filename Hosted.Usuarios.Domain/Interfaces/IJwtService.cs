using System.Security.Claims;

namespace Hosted.Usuarios.Domain.Interfaces {
    public interface IJwtService {
        string GenerateJwt(List<Claim> claims);
    }
}
