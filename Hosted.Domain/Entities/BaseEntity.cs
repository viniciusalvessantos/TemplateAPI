using System.ComponentModel.DataAnnotations;

namespace Hosted.Domain.Entities {
    public class BaseEntity {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;

        [ConcurrencyCheck]
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public string Description { get; set; }  // exemplo simples usando ConcurrencyCheck
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.

        [Timestamp]
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public byte[] RowVersion { get; set; }  // controle de concorrência usando Timestamp
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
    }
}
