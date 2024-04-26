namespace Hosted.Usuarios.Application.Responses.RegisterResponser {
    public class RegisterResponser {

        public RegisterResponser(string menssagem) {
            MessagemResponser = menssagem;
        }
        public string MessagemResponser { get; }
    }
}
