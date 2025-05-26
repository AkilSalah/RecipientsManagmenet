using System.ComponentModel.DataAnnotations;

namespace Gestion_Destinataire.Models
{
    public class Destinataire
    {
        [Key]
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required string Email { get; set; }
    }
}
