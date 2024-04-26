namespace Hosted.Usuarios.Application.Responses.LoginResponses {
    public class LoginResponse {
        public LoginResponse(string token) {
            Token = token;
        }
        public string Token { get; }
    }
}
