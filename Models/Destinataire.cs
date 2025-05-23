using System.ComponentModel.DataAnnotations;

namespace Gestion_Destinataire.Models
{
    public class Destinataire
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
    }
}
