using Hosted.Exceptions.Abstraction;

namespace Hosted.Usuarios.Domain.Exceptions {
    public class LoginTenantException : AppException {
        public LoginTenantException() : base("", 104) {
        }
    }
}
