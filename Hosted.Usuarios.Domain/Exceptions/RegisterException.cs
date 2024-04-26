using Hosted.Exceptions.Abstraction;
using Microsoft.AspNetCore.Identity;

namespace Hosted.Usuarios.Domain.Exceptions {
    public class RegisterException : ModularMonolithValidationException {
        public RegisterException(IEnumerable<IdentityError> errors) : base("Unable to register account.", 102) {
            ValidationMessages = errors.Select(x => x.Description).ToList();
        }
    }
}
