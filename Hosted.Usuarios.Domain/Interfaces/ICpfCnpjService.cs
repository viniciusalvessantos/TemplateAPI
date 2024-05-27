namespace Hosted.Usuarios.Domain.Interfaces {
    public interface ICpfCnpjService {

        bool validarCpf(string cpf);
        bool validarCnpj(string cnpj);

    }
}
