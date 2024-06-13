using Hosted.Exceptions.Abstraction;

namespace Hosted.Usuarios.Domain.Exceptions {
    public class RegisterTenantException : ModularMonolithValidationException {
        public RegisterTenantException() : base("Erro ao registrar a instituição", 105) {
        }
    }
}
