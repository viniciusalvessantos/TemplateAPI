using Hosted.Domain.Entities;

namespace Hosted.Whatsapp.Domain.Entities {
    internal class Whatsapp : BaseEntity {
        public string Numero { get; set; }
        public string Session { get; set; }
        public Guid IdUsuario { get; set; }
        public byte Status { get; set; }
    }
}
