using Hosted.Usuarios.Application.Responses.LoginResponses;
using MediatR;

namespace Hosted.Usuarios.Application.Queries.Login {
    public class LoginQuery : IRequest<LoginResponse> {
        public LoginQuery(string userName, string password) {
            UserName = userName;
            Password = password;
        }
        public string UserName { get; }
        public string Password { get; }
    }
}
