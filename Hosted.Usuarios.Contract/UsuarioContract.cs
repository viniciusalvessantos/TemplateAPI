namespace Hosted.Usuarios.Contract {
    public class UsuarioContract {

        public UsuarioContract(string name, string surname, string email) {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }
        public string FullName => $"{Name} {Surname}";
    }
}
