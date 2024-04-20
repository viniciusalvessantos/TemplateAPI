using Hosted.Exceptions.Abstraction;

namespace Hosted.Usuarios.Domain.Exceptions {
    public class LoginException : AppException {
        public LoginException() : base("Unable to login. Wrong Username or Password", 102) {
        }
    }
}
